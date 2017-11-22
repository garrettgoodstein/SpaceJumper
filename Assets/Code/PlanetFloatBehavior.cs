using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFloatBehavior : MonoBehaviour {

	static float THRESHOLD = 2;

	float initX;
	float initY;
	float initZ;
	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = transform.GetComponent<Rigidbody>();
		initX = transform.position.x;
		initY = transform.position.y;
		initZ = transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {
		int randTypeForce = Random.Range (0, 3);
		int force = Random.Range (7, 12); 


		if (randTypeForce == 0) {
			rb.AddForce (0, force, force);
		}
		if (randTypeForce == 1) {
			rb.AddForce (force, 0, 0);
		}
		if (randTypeForce == 2) {
			rb.AddForce (0, -force, -force);
		}
		if (randTypeForce == 3) {
			rb.AddForce (-force, 0, 0);
		}
			

		if (transform.position.x > initX + THRESHOLD) {
			rb.AddForce (-force, 0, 0);
			//Debug.Log ("if: "+transform.position.x);
		} else {
			rb.AddForce (force, 0, 0);
			//Debug.Log ("else: "+transform.position.x);
		}

		if (transform.position.y > initY + THRESHOLD) {
			rb.AddForce (0, -force, 0);
			//Debug.Log ("if: "+transform.position.y);
		} else {
			rb.AddForce (0, force, 0);
			//Debug.Log ("else: "+transform.position.y);
		}

		if (transform.position.z > initZ + THRESHOLD*1000) {
			rb.AddForce (0, 0, -force);
			//Debug.Log ("if: "+transform.position.y);
		} else {
			rb.AddForce (0, 0, force);
			//Debug.Log ("else: "+transform.position.y);
		}
	}
}
