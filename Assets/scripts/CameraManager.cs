using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public float minFov, maxFov;

	public Rigidbody2D target;
	Camera cam;
	void Start()
	{
		cam = Camera.main;
		transform.position = target.transform.position;
	}

	void Update()
	{
		transform.position = target.transform.position;// Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime*10);
		
		float vel = Mathf.Abs((target.velocity.x + target.velocity.y)/2);
		bool fast = vel > 4;
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, fast? maxFov : minFov, Time.deltaTime * 0.2f);
	}

}
