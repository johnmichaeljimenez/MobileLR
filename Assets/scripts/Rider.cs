using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour {

	private static Rider _main;
	public static Rider main
	{
		get{
			if (!_main)
				_main = GameObject.FindObjectOfType<Rider>();

			return _main;
		}
	}

	public float accelerationAmount = 12;

	Rigidbody2D _r2;
	Rigidbody2D rigidbody
	{
		get{
			if (!_r2)
			{
				_r2 = GetComponent<Rigidbody2D>();
			}

			return _r2;
		}
	}

	Vector2 prevVelocity;
	float prevAngVelocity;

	float acceleration;
	// Use this for initialization
	void Start () {
		acceleration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (PlaybackManager.isPlaying != PlaybackManager.PlayStates.Playing)
			return;

		if (acceleration > 0)
			acceleration -= 1f;
		else
			acceleration = 0;
	}

	public void SetPlayback(PlaybackManager.PlayStates p)
	{
		print(p.ToString());
		switch (p)
		{
			case PlaybackManager.PlayStates.Stop:
				// rigidbody.velocity = Vector2.zero;
				// rigidbody.angularVelocity = 0;
				// rigidbody.bodyType = RigidbodyType2D.Static;
				// acceleration = 0;

				Time.timeScale = 0;
				transform.position = Vector3.zero;
				transform.rotation = Quaternion.identity;
				// prevAngVelocity = 0;
				// prevVelocity = Vector2.zero;
				break;
			case PlaybackManager.PlayStates.Playing:
				// rigidbody.bodyType = RigidbodyType2D.Dynamic;
				// // rigidbody.AddForce(prevVelocity); // * rigidbody.mass / Time.fixedDeltaTime
				// // rigidbody.AddTorque(prevAngVelocity);
				// rigidbody.WakeUp();
				// rigidbody.velocity = prevVelocity;
				// rigidbody.angularVelocity = prevAngVelocity;
				Time.timeScale = 1;
				break;
			case PlaybackManager.PlayStates.Pause:
				// prevVelocity = rigidbody.velocity;
				// prevAngVelocity = rigidbody.angularVelocity;
				// rigidbody.velocity = Vector2.zero;
				// rigidbody.angularVelocity = 0;
				// rigidbody.bodyType = RigidbodyType2D.Static;
				Time.timeScale = 0;
				break;
			default:
				break;
		}
	}

	void OnCollisionStay2D(Collision2D c)
	{
		if (PlaybackManager.isPlaying != PlaybackManager.PlayStates.Playing)
			return;

		EdgeCollider2D e = c.gameObject.GetComponent<EdgeCollider2D>();
		Accelerator a = c.gameObject.GetComponent<Accelerator>();

		if (a)
		{
			if (acceleration < accelerationAmount)
				acceleration += 2f;
				
			Vector3 temp = Vector3.Cross(c.contacts[0].normal, transform.right);
		    Vector3 myDirection = Vector3.Cross(temp, c.contacts[0].normal);

			rigidbody.AddForce(myDirection * acceleration, ForceMode2D.Force);
		}
	}
}
