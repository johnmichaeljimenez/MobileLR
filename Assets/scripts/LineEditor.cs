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

        var recognizer = new TKPanRecognizer();

        recognizer.gestureRecognizedEvent += (r) =>
        {
			OnPressStart(r.touchLocation());
        };

        // continuous gestures have a complete event so that we know when they are done recognizing
        recognizer.gestureCompleteEvent += r =>
        {
			OnPressEnd(r.touchLocation());
        };

		TouchKit.addGestureRecognizer(recognizer);
    }

	public void OnPressStart(Vector2 point)
	{
		print(point.ToString());
	}

	public void OnPressEnd(Vector2 point)
	{
		print(point.ToString());
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
