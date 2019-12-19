using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_body : MonoBehaviour {

	Rigidbody rb;
	public int N = 2;
	Vector3 r;
	public Vector3 V;
	GameObject[] GO = new GameObject[4];
	float g = 6.67408e-2F;
	public float m,M;	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.position= r;
		rb.velocity = V;

		int y = -2, x = -3, k=0;
		for (int i = 0; i < N; ++i,y+=3) {
			for (int j = 0; j < N; ++j,x+=3) {
				GO[k] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				GO[k].AddComponent<Rigidbody>();
				GO [k].GetComponent<Rigidbody> ().useGravity = false;
				GO[k].transform.position = new Vector3(x, y, 0);
				Debug.Log (i.ToString() +' '+ j.ToString());
				k++;
			}
		}
	}

	void Update ()
	{
		for (int i = 0; i < 4; i++) 
		{
			for (int k = 0; i!=k && k < 4; k++) 
			{
				r = GO[i].transform.position - GO [k].transform.position;
				float l = -g * m / Mathf.Pow (r.magnitude, 3);
				rb.AddForce (l * r );

				Debug.Log (r);
			}
		}
	}
}
