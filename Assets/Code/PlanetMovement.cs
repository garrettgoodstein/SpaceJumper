using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// SpaceWanderer 
// October 19th, 2017
// Team Anhagama 

public class PlanetMovement : MonoBehaviour {
	float xSpeed;
	float ySpeed;
	float zSpeed;

	// Use this for initialization
	void Start () {
		if (transform.position.x > 0) {
			xSpeed = -0.01f;
			ySpeed = -0.01f;
			zSpeed = 0.0f;
		} 
		else {
			xSpeed = 0.01f;
			ySpeed = -0.01f;
			zSpeed = 0.0f; 

		}

	}

	// Update is called once per frame
	void Update () {
		// X axis
		//		if (transform.position.x <= -1100f || transform.position.x >= 1100f) {
		//			xSpeed = -xSpeed;
		//		}
		// Y axis
		//		if (transform.position.y <= -470f || transform.position.y >= 470f) {
		//			ySpeed = -ySpeed;
		//		}
		transform.Translate(xSpeed, ySpeed, zSpeed);
		transform.localScale += new Vector3 (0.00f, 0.00f, 0);
	}
}
