using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Internal.Filters;
using System.Runtime.InteropServices;

// SpaceWanderer 
// October 19th, 2017
// Team Anhagama 

//Github test Matthew Bonazzoli
public class PlanetMoveDemo : MonoBehaviour {
	float xSpeed;
	float ySpeed;
	// Use this for initialization
	void Start () {
		xSpeed = 1f;
		ySpeed = 1f;
		
	}
	
	// Update is called once per frame
	void Update () {
		// X axis
		if (transform.position.x <= -1100f || transform.position.x >= 1100f) {
			xSpeed = -xSpeed;
		}
		// Y axis
		if (transform.position.y <= -470f || transform.position.y >= 470f) {
			ySpeed = -ySpeed;
		}
		transform.Translate(xSpeed, ySpeed, 0f);
		//transform.localScale += new Vector3 (1f, 1f, 0f);

		//transform.RotateAround (0f,0f,0f);
			
	}
}
