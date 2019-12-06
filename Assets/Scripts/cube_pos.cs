using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_pos : MonoBehaviour {
	
	Rigidbody rb;
	public Rigidbody rb1;
	public Vector3 r;
	public Vector3 R;
	public Vector3 V;
	float g = 6.67408e-2F;
	public float m;
	public float M;



	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.position= r;
		rb.velocity = V;

		Debug.Log (rb.position);
	}

	void Update ()
	{
		
		r = rb.position-rb1.position;
		R = rb.position;
		float l = -g * m / Mathf.Pow (r.magnitude, 3);
		float L = -g * M / Mathf.Pow (R.magnitude, 3);
		rb.AddForce (l*r+L*R);
		Debug.Log (l*r);

	}
}
