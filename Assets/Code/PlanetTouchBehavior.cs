using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 0.0F;
	public Vector3 constantScale = new Vector3 (62, 30);

<<<<<<< HEAD
	private GameObject findClosestPlanet(Touch touch) 
	// Finds the closests planet in relation to the prince's position. 
	// The code for this method is borrowed from Unity's documentation.
	// url: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html

	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Planet");
		GameObject closestPlanet = null;
		float distance = Mathf.Infinity;
		Vector3 position = touch.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closestPlanet = go;
				distance = curDistance;
			}
		}
//		closestPlanet.tag = "HomePlanet";
		return closestPlanet;
	}

=======
	// Use this for initialization
>>>>>>> bda84e5219d82282e82a80248b7754e9415e4811
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);

			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 0));
				transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime);

<<<<<<< HEAD
				var closestPlanetPosition = findClosestPlanet(touch).transform.position;
				var closestPlanet = findClosestPlanet(touch);
				var princePosition = GameObject.FindGameObjectWithTag ("Prince").transform.position;
				var currentHomePlanet = GameObject.FindGameObjectWithTag ("HomePlanet");

				transform.position = Vector3.MoveTowards (closestPlanetPosition, transform.position, Time.deltaTime); //Move

				currentHomePlanet.tag = "Planet"; //Update
				closestPlanet.tag = "HomePlanet";

				}
=======
			
			}
>>>>>>> bda84e5219d82282e82a80248b7754e9415e4811
		}
	}

<<<<<<< HEAD

}

=======
>>>>>>> bda84e5219d82282e82a80248b7754e9415e4811
