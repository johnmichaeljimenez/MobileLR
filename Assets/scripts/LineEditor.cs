using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEditor : MonoBehaviour {

	private static LineEditor _main;
	public static LineEditor main
	{
		get{
			if (!_main)
			{
				_main = GameObject.FindObjectOfType<LineEditor>();
			}

			return _main;
		}
	}

	LineEditMode lineEditMode;

	void Awake () {
		
		SetEditMode(LineEditMode.DrawNormal);
	}
	
	void Update () {
		
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
