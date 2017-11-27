﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTouchBehavior : MonoBehaviour {
	public float speed = 0.0F;

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

	void Start () {}

	void Update () {
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)) {
				// If the finger is on the screen, move the object smoothly to the touch position

				var step = Time.deltaTime * speed;

				var closestPlanetPosition = findClosestPlanet(touch).transform.position;
				var closestPlanet = findClosestPlanet(touch);
				var currentHomePlanet = GameObject.FindGameObjectWithTag ("HomePlanet");

				transform.position = Vector2.MoveTowards (closestPlanetPosition, transform.position, Time.deltaTime * speed); //Move

				currentHomePlanet.tag = "Planet"; //Update
				closestPlanet.tag = "HomePlanet";
				}
		}
	}
}

