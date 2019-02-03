using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackManager : MonoBehaviour {

	private static PlaybackManager _main;
	public static PlaybackManager main
	{
		get{
			if (!_main)
				_main = GameObject.FindObjectOfType<PlaybackManager>();

			return _main;
		}
	}


	private static PlayStates _isPlaying;
	public static PlayStates isPlaying
	{
		get{
			return _isPlaying;
		}

		set{
			if (_isPlaying != value)
			{
				_isPlaying = value;
				main.OnPlaybackChange();
			}
		}
	}

	void Awake()
	{
		_isPlaying = PlayStates.Pause;
		isPlaying = PlayStates.Stop;
	}

	void OnPlaybackChange()
	{
		print("playback change");
		Rider.main.SetPlayback(isPlaying);
		EditorButton.SetCurrent(EditorButton.current);

		switch (isPlaying)
		{
			case PlayStates.Playing:
				break;
			case PlayStates.Pause:
				CameraManager.main.PauseCamera();
				break;
			case PlayStates.Stop:
				break;
		}
	}

	public void SetPlayback(PlayStates p)
	{
		isPlaying = p;
		HUD.main.toolGroup.gameObject.SetActive(p != PlayStates.Playing);
	}

	public enum PlayStates
	{
		Stop, Playing, Pause
	}
}
