using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour {

	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		EdgeCollider2D e = c.gameObject.GetComponent<EdgeCollider2D>();
		Accelerator a = c.gameObject.GetComponent<Accelerator>();

		if (a)
		{
			Vector2 v = (e.points[1] - e.points[0]).normalized * a.amount;
			rigidbody.AddForce(v, ForceMode2D.Force);
		}
	}
}
