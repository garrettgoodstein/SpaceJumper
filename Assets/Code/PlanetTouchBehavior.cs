using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 0.1F;
	public Vector3 constantScale = new Vector3 (62, 30);

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			var clickedPosition = touch.position;

			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved ) || Physics.CheckSphere(clickedPosition, 100)) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y));
				transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime); 

			}
		}
}
}
