using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 0.0F;
	public Vector3 constantScale = new Vector3 (62, 30);

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			var clickedPosition = touch.position;

			Vector3 touchPos = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y));
			Vector2 mousePos2D = new Vector3(touchPos.x,touchPos.y);

			var princePositionX = GameObject.FindGameObjectWithTag("Prince").transform.position.x;
			var princePositionY = GameObject.FindGameObjectWithTag ("Prince").transform.position.y;
			var princePositionZ = GameObject.FindGameObjectWithTag ("Prince").transform.position.z;


			var planetPositionX = GameObject.FindGameObjectWithTag("Planet").transform.position.x;
			var planetPositionY = GameObject.FindGameObjectWithTag("Planet").transform.position.y;
			var planetPositionZ = GameObject.FindGameObjectWithTag("Planet").transform.position.z;

			var touchDifferenceX = princePositionX - planetPositionX;
			var touchDifferenceY = princePositionY - planetPositionY;
			var touchDifferenceZ = princePositionZ - planetPositionZ;

			print ("touchX " + touchDifferenceX);
			print ("touchY " + touchDifferenceY);
			print ("touchZ " + touchDifferenceZ);

			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved )) {
			// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (planetPositionX, planetPositionY));
				transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime); 
			
		}
		}
	}
}

