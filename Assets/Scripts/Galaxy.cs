using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {
	
	public Transform aroundPoint;//вокруг какого объекта крутиться
	public float circleInSecond = 0.6f;//кругов в секунду

	public float offsetSin = 1.1f; //если значения не 1, то будет овальное смещение
	public float offsetCos = 1.2f;

	float dist;
	float circleRadians = Mathf.PI * 2;
	float currentAng = 0;

	void Start()
	{
		dist = (transform.position - aroundPoint.position).magnitude;
	}

	void Update()
	{
		Vector3 p = aroundPoint.position;
		p.x += Mathf.Sin(currentAng) * dist * offsetSin;
		p.z += Mathf.Cos(currentAng) * dist * offsetCos;
		transform.position = p;

		currentAng += circleRadians * circleInSecond * Time.deltaTime;
	}
}