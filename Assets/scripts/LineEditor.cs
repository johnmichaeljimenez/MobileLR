using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEditor : MonoBehaviour
{

    private static LineEditor _main;
    public static LineEditor main
    {
        get
        {
            if (!_main)
            {
                _main = GameObject.FindObjectOfType<LineEditor>();
            }

            return _main;
        }
    }

    LineEditMode lineEditMode;

	Vector3 linePos1, linePos2;
    LineDrawState lineDrawState;

    void Awake()
    {
		TouchKit.instance.debugDrawBoundaryFrames = true;

        SetEditMode(LineEditMode.DrawNormal);

        //pan camera
        var panRecognizer = new TKPanRecognizer();
        panRecognizer.gestureRecognizedEvent += (r) =>
        {
			OnPanCamera(r);
        };
		TouchKit.addGestureRecognizer(panRecognizer);

        //pinch zoom
        var pinchRecognizer = new TKPinchRecognizer();
        pinchRecognizer.gestureRecognizedEvent += (r) =>
        {
            OnZoomCamera(r);
        };
        TouchKit.addGestureRecognizer(pinchRecognizer);

        //draw
        var drawRecognizer = new TKButtonRecognizer(new TKRect(0, 0, Screen.width, Screen.height));
        drawRecognizer.zIndex = 0;
        drawRecognizer.onSelectedEvent += (r) =>
        {
            print(r);
            OnDrawLineStart(r);
        };
        drawRecognizer.onTouchUpInsideEvent += (r) =>
        {
            print(r);
            OnDrawLineEnd(r);
        };
        TouchKit.addGestureRecognizer(drawRecognizer);
    }

	public void OnPanCamera(TKPanRecognizer t)
	{
        if (lineEditMode != LineEditMode.Camera)
            return;

        CameraManager.main.PanCamera(-t.deltaTranslation*CameraManager.main.panSpeed);
	}

    public void OnDrawLineStart(TKButtonRecognizer t)
    {
        if (lineEditMode == LineEditMode.Camera || lineEditMode == LineEditMode.Erase)
            return;
            

        if (lineDrawState != LineDrawState.Start)
        {
            lineDrawState = LineDrawState.Start;
            linePos1 = t.touchLocation();
            return;
        }
    }
    
    public void OnDrawLineEnd(TKButtonRecognizer t)
    {
        if (lineEditMode == LineEditMode.Camera || lineEditMode == LineEditMode.Erase)
            return;

        if (lineDrawState != LineDrawState.Start)
            return;

        linePos2 = t.touchLocation();
        lineDrawState = LineDrawState.None;

        if ((linePos1-linePos2).magnitude <= 10)
            return;

        linePos1 = Camera.main.ScreenToWorldPoint(linePos1);
        linePos2 = Camera.main.ScreenToWorldPoint(linePos2);

        LineWorld.main.AddLine(linePos1, linePos2);
    }
    

	public void OnZoomCamera(TKPinchRecognizer t)
	{
        if (lineEditMode != LineEditMode.Camera)
            return;

        if (Mathf.Abs(t.deltaScale) <= 0)
            return;

        print(t.deltaScale);
        CameraManager.main.ZoomCamera(-t.deltaScale*CameraManager.main.zoomSpeed);
	}

    void Update()
    {

    }

    public void SetEditMode(LineEditMode e)
    {
        lineEditMode = e;
        HUD.main.SetCurrentTool(e);
        lineDrawState = LineDrawState.None;
    }

    public enum LineEditMode
    {
        DrawNormal, DrawAccelerator, DrawBounce, DrawBrake, Erase, Camera
    }

    public enum LineDrawState
    {
        None,
        Start
    }
}
