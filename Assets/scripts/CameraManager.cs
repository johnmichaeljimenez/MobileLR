using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	private static CameraManager _main;
	public static CameraManager main
	{
		get{
			if (!_main)
				_main = GameObject.FindObjectOfType<CameraManager>();

			return _main;
		}
	}

	Vector3 editorPosition;
	float editorFov;

	public float minFov, maxFov;
	public float panSpeed = 0.1f, zoomSpeed = 0.1f;

	public Rigidbody2D target;
	Camera cam;

	void Start()
	{
		cam = Camera.main;
		transform.position = target.transform.position;

		editorPosition = target.transform.position;
		editorFov = minFov;
	}

	void Update()
	{
		if (PlaybackManager.isPlaying != PlaybackManager.PlayStates.Playing)
		{
			transform.position = editorPosition;
			cam.orthographicSize = editorFov;
			return;
		}

		transform.position = target.transform.position;// Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime*10);
		
		float vel = Mathf.Abs((target.velocity.x + target.velocity.y)/2);
		bool fast = vel > 4;
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, fast? maxFov : minFov, Time.deltaTime * 0.2f);
	}

	public void PauseCamera()
	{
		editorPosition = target.transform.position;
		editorFov = minFov;
	}

	public void PanCamera(Vector2 p)
	{
		editorPosition += new Vector3(p.x, p.y);
	}

	public void ZoomCamera(float f)
	{
		editorFov = Mathf.Clamp(editorFov+f, minFov, maxFov);
	}

}
