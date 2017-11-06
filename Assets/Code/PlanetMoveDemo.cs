using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

// SpaceWanderer 
// October 19th, 2017
// Team Anhagama 

public class PlanetMoveDemo : MonoBehaviour {
	float xSpeed;
	float ySpeed;
	// Use this for initialization
	void Start () {
		if (transform.position.x > 0) {
			xSpeed = -1.2f;
			ySpeed = -0.5f;
		} 
		else {
			xSpeed = 1f;
			ySpeed = -0.5f;
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
		transform.Translate(xSpeed, ySpeed, 0f);
		transform.localScale += new Vector3 (0.03f, 0.03f, 0f);
	}
}
