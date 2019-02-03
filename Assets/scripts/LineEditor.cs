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

    void Awake()
    {

        SetEditMode(LineEditMode.DrawNormal);

        var panRecognizer = new TKPanRecognizer();
        panRecognizer.gestureRecognizedEvent += (r) =>
        {
			OnPanCamera(r);
        };
		TouchKit.addGestureRecognizer(panRecognizer);

        var pinchRecognizer = new TKPinchRecognizer();
        pinchRecognizer.gestureRecognizedEvent += (r) =>
        {
            OnZoomCamera(r);
        };
        TouchKit.addGestureRecognizer(pinchRecognizer);
    }

	public void OnPanCamera(TKPanRecognizer t)
	{
        if (lineEditMode != LineEditMode.Camera)
            return;

        CameraManager.main.PanCamera(-t.deltaTranslation*CameraManager.main.panSpeed);
	}
    

	public void OnZoomCamera(TKPinchRecognizer t)
	{
        // if (lineEditMode != LineEditMode.Camera)
        //     return;

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
    }

    public enum LineEditMode
    {
        DrawNormal, DrawAccelerator, DrawBounce, DrawBrake, Erase, Camera
    }
}
