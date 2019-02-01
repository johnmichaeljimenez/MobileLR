using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour {

	public float accelerationAmount = 12;

	Rigidbody2D rigidbody;

	float acceleration;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		acceleration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (acceleration > 0)
			acceleration -= 1f;
		else
			acceleration = 0;
	}

	void OnCollisionStay2D(Collision2D c)
	{
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
