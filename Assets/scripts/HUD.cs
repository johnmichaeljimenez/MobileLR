using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    private static HUD _main;
    public static HUD main
    {
        get
        {
            if (!_main)
                _main = GameObject.FindObjectOfType<HUD>();

            return _main;
        }
    }

    public Button drawNormal;
    public Button drawAccelerator;
    public Button drawBounce;
    public Button drawBrake;
    public Button erase;
    public Button camera;
    public Button undo;
    public Button redo;


    public Button play;
    public Button pause;
    public Button stop;
    public Button load;
    public Button save;


    void Start()
    {
		


		play.SetOnClickListener(()=>{ PlaybackManager.main.SetPlayback(PlaybackManager.PlayStates.Playing); });
		pause.SetOnClickListener(()=>{ PlaybackManager.main.SetPlayback(PlaybackManager.PlayStates.Pause); });
		stop.SetOnClickListener(()=>{ PlaybackManager.main.SetPlayback(PlaybackManager.PlayStates.Stop); });
    }

    public void SetCurrentTool(LineEditor.LineEditMode e)
    {

        switch (e)
        {
            case LineEditor.LineEditMode.DrawNormal:
                EditorButton.SetCurrent(drawNormal);
                break;
            case LineEditor.LineEditMode.DrawAccelerator:
                EditorButton.SetCurrent(drawAccelerator);
                break;
            case LineEditor.LineEditMode.DrawBounce:
                EditorButton.SetCurrent(drawBounce);
                break;
            case LineEditor.LineEditMode.DrawBrake:
                EditorButton.SetCurrent(drawBrake);
                break;
            case LineEditor.LineEditMode.Erase:
                EditorButton.SetCurrent(erase);
                break;
            case LineEditor.LineEditMode.Camera:
                EditorButton.SetCurrent(camera);
                break;
            default:
                break;
        }
    }
}
