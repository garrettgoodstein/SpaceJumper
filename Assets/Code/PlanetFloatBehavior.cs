using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFloatBehavior : MonoBehaviour {

	static float THRESHOLD = 3;
	float initX;
	float initY;
	float initZ;
	Rigidbody rb;
	SpriteRenderer sr;
	GameObject planet;
	PlanetGenerator generatorScript;


	// Use this for initialization
	void Start () {

		rb = gameObject.GetComponent<Rigidbody> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();

		initX = transform.position.x;
		initY = transform.position.y;
//		initZ = transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {

		int randTypeForce = Random.Range (0, 3);
		int force = Random.Range (10, 12); 


		if (randTypeForce == 0) {
			rb.AddForce (0, force, 0);
		}
		if (randTypeForce == 1) {
			rb.AddForce (force, 0, 0);
		}
		if (randTypeForce == 2) {
			rb.AddForce (0, -force, 0);
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

		if (transform.position.z > initZ + THRESHOLD - 2000) {
			rb.AddForce (0, 0, -force);
			//Debug.Log ("if: "+transform.position.y);
		} 
//		else {
//			rb.AddForce (0, 0, force);
//			//Debug.Log ("else: "+transform.position.y);
//	}

		//deleteIfNotVisible ();
	}

	void LateUpdate(){
		if (sr.isVisible) {
//			relocate ();
//			Debug.Log ("relocated");
		} else {
			relocate ();
//			Debug.Log ("relocated");
		}
	}

	void relocate(){
		//		Texture2D blend = blendTextures ();
		//		planetRenderer.sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.0f, 0.0f), 10.0f) as Sprite;

		// TODO: need to see if the position of the planet can be modified without using translate or addforce
		// doesn't work
		transform.position = new Vector3 (Random.Range (-800, 800), Random.Range (-800, 800), Random.Range (1000, 1200));


	}



//	void deleteIfNotVisible(){
//		if (!sr.isVisible) {
//			Destroy (gameObject, 10);
//		}
//	
//	}
}
