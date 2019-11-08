using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	Rigidbody rb;
	Vector3 r;	//радиус вектор
	float g = 9.8F;
	public float l = 3F;	//начальное расстояние до точки притяжения 
	float fw( float Phi) {
		r.x = Mathf.Sin (Phi);	//перехожу от фи к ху
		r.y = - Mathf.Cos (Phi);
		Vector3 f = ( -r / 3 )* g / Mathf.Pow(l,2) ;	// тут получаю вектор силы
		return Mathf.Atan (f.x / f.y);	//перехожу от вектора к фи
	}
	float fp( float w) { return w; }

	float RungeP( float W, float h) {
		float  k1 = 0, k2 = 0, k3 = 0, k4 = 0;
		k1 = h * fp(W);
		k2 = h * fp(W + (1 / 2)*k1);
		k3 = h * fp(W + (1 / 2)*k2);
		k4 = h * fp(W + k3);
		return k1 / 6 + 2 * k2 / 6 + 2 * k3 / 6 + k4 / 6;
	}
	float RungeW(float P, float h) {
		float  k1 = 0, k2 = 0, k3 = 0, k4 = 0;
		k1 = h * fw(P);
		k2 = h * fw(P + (1 / 2)*k1);
		k3 = h * fw(P + (1 / 2)*k2);
		k4 = h * fw(P + k3);
		return  k1 / 6 + 2 * k2 / 6 + 2 * k3 / 6 + k4 / 6;
	}
	float W, P, Pn, Wn;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		r = rb.position;
		W = 0;
		P = Mathf.PI / 2;
		Debug.Log (rb.position);
	}

	void Update ()
	{
		//F = ( -rb.position / 3 )* g / Mathf.Pow(r,2) ;
		float h = Time.deltaTime;

		//for (int i = 1; i <= n; i++)
		Wn =W + RungeW (P, h);
		Pn =P + RungeP (W, h);
		rb.position = new Vector3 (
					l*Mathf.Sin ( Pn ),		//x
					-l * Mathf.Cos ( Pn ),	//y
					0f);
		Debug.Log (rb.position);
		P = Pn;
		W = Wn;
	}
}
