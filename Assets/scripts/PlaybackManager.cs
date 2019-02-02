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
				_isPlaying = value;
		}
	}

	void Awake()
	{
		_isPlaying = PlayStates.Pause;
		isPlaying = PlayStates.Stop;
	}

	void OnPlaybackChange()
	{
		
	}

	public enum PlayStates
	{
		Stop, Playing, Pause
	}
}
