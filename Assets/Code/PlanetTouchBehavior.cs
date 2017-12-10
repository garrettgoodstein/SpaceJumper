using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetTouchBehavior : MonoBehaviour {
	GameObject target = null;

	void Start () {}

	void Update () {
		if (Input.touchCount == 1) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0); 

			if (touch.phase == TouchPhase.Ended) {
				var touchPosition = touch.position;
				print ("Touch Position: " + touchPosition);
				Camera c = Camera.main;
				print ("Screen pixels: " + c.pixelWidth + ":" + c.pixelHeight);

				//FIND THE LOCAL TOUCH POSITION
				var screenTouch = c.WorldToScreenPoint (touchPosition);
				print ("Screen Touch: " + screenTouch);
				Vector3 worldTouch = c.ScreenToWorldPoint (new Vector3 (touchPosition.x, touchPosition.y, transform.position.z + 500));
				print ("World: " + worldTouch);
				GameObject closestPlanet = findClosestPlanet (touchPosition);
				Vector3 closestPlanetPosition = closestPlanet.transform.position;

				print ("Prince Position: " + transform.position);

				transform.parent.tag = "Planet";
				transform.parent = null;

				target = closestPlanet;
//				closestPlanet.tag = "HomePlanet";
			}
		}
		if (target != null){
			//@targetCoord = planet coordination
			//@transform.position = prince
			Vector3 targetCoord = new Vector3 (target.transform.position.x+50,
			                    target.transform.position.y+100, target.transform.position.z);
			float step = Time.deltaTime * 60;
			transform.position = Vector3.MoveTowards (transform.position, targetCoord, step);
			if (transform.position == targetCoord) {
				target.tag = "HomePlanet";
				transform.parent = target.transform;
				target.GetComponent<HomePlanetMove>();
			}
		}
	}

	private GameObject findClosestPlanet(Vector2 touch) 
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Planet");
		print ("Game Objects: " + gos);
		GameObject closestPlanet = null;
		float distance = Mathf.Infinity;
		foreach (GameObject go in gos)
		{
			print ("Planet Position:" + go.transform.position + "| Screen Position: " + Camera.main.WorldToScreenPoint(go.transform.position));
			//planet position - touch position
			Vector2 diff = new Vector2(Math.Abs(Camera.main.WorldToScreenPoint(go.transform.position).x - touch.x), Math.Abs(Camera.main.WorldToScreenPoint(go.transform.position).y - touch.y));
			// curDistance = the radius^2 bewteen the touch and planet
			float curDistance = (float)(Math.Pow (diff.x, 2) + Math.Pow (diff.y, 2));

			// if the distance between touch and planet is not infinite, make the distance to be the touch_vs_planet_distance
			if (curDistance < distance)
			{
				closestPlanet = go;
				distance = curDistance;
			}
		}
		return closestPlanet;
	}
}