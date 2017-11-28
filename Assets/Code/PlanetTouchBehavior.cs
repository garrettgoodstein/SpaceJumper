using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 10000.0F;

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
		return closestPlanet;
	}

	void Start () {}

	void Update () {
		if (Input.touchCount == 1) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)) {
				// If the finger is on the screen, move the object smoothly to the touch position

				var step = Time.deltaTime * speed;

				var closestPlanetPosition = findClosestPlanet(touch).transform.position;
				var closestPlanet = findClosestPlanet(touch);
				var currentHomePlanet = GameObject.FindGameObjectWithTag ("HomePlanet");

//				for (int i = 1; i <= 100; i++) {
//					
//				}

				print ("no change" + closestPlanetPosition);
				print ("This is the test" + closestPlanetPosition / 100); 

				transform.position = Vector2.MoveTowards (transform.position, closestPlanetPosition, step); // Move

				currentHomePlanet.tag = "Planet"; //Update
				closestPlanet.tag = "HomePlanet";
				}
		}
	}
}

