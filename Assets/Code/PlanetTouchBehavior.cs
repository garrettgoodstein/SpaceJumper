using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 0.0F;

	void Start () {}

	void Update () {
		if (Input.touchCount == 1) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)) {
				// If the finger is on the screen, move the object smoothly to the touch position
				var step = Time.deltaTime * speed;

				var randomPlanet = GameObject.FindGameObjectWithTag ("Planet"); // Matt's random planets are tagged as "Planet".
				var planetPosition = randomPlanet.transform.position;

				transform.position = Vector3.MoveTowards (transform.position, planetPosition, step); // Move

				randomPlanet = GameObject.FindGameObjectWithTag ("Planet");

				// OLD CODE BELOW. 

//				var closestPlanetPosition = findClosestPlanet(touch).transform.position;

//				print ("closest" + closestPlanetPosition);
//				var closestPlanet = findClosestPlanet(touch);
//				var currentHomePlanet = GameObject.FindGameObjectWithTag ("HomePlanet");

//				transform.position = Vector3.MoveTowards (transform.position, closestPlanetPosition, step); // Move

				// TODO: The change in tags below should not happen until the prince has safely reached the planet that the user clicked on.

//				currentHomePlanet.tag = "Planet"; //Update
//				closestPlanet.tag = "HomePlanet";
				}
		}
	}

	// OLD METHOD BELOW. IGNORE
	//	private GameObject findClosestPlanet(Touch touch) 
	//	// Finds the closests planet in relation to the prince's position. 
	//	// The code for this method is borrowed from Unity's documentation.
	//	// url: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
	//
	//	{
	//		GameObject[] gos;
	//		gos = GameObject.FindGameObjectsWithTag("Planet");
	//		GameObject closestPlanet = null;
	//		float distance = Mathf.Infinity;
	//		Vector3 position = touch.position;
	//		foreach (GameObject go in gos)
	//		{
	//			Vector3 diff = go.transform.position - position;
	//			float curDistance = diff.sqrMagnitude;
	//			if (curDistance < distance)
	//			{
	//				closestPlanet = go;
	//				distance = curDistance;
	//			}
	//		}
	//		return closestPlanet;
	//	}
}

