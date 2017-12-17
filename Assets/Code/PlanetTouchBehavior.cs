using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Specialized;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class PlanetTouchBehavior : MonoBehaviour {
	GameObject target = null;
	Animator anim;

	double initialDist = 0;


	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetInteger ("PlayerState", 0);
		Debug.Log (anim.GetInteger("PlayerState"));
	}

	void Update () {
		if (Input.touchCount == 1) {
			// The screen has been touched so store the touch
			anim.SetInteger ("PlayerState", 1);

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
				target = findClosestPlanet (touchPosition);

				print ("Prince Position: " + transform.position);

				transform.parent.tag = "Planet";
				transform.parent = null;

				initialDist = Math.Pow (Math.Abs(transform.position.x - target.transform.position.x),2) + Math.Pow (Math.Abs(transform.position.z - target.transform.position.z),2);
			}
		}
// <<<<<<< HEAD
// 		if (target != null) {
// 			//@targetCoord = planet coordination
// 			//@transform.position = prince
// 			Vector3 targetCoord = new Vector3 (target.transform.position.x+50,
// 			                    target.transform.position.y+100, target.transform.position.z);
// 			float step = Time.deltaTime * 60;
// 			transform.position = Vector3.MoveTowards (transform.position, targetCoord, step);
// 			if (transform.position == targetCoord) {
// =======
		if (target != null){
			double currentDist = Math.Pow (Math.Abs(transform.position.x - target.transform.position.x),2) + Math.Pow (Math.Abs(transform.position.z - target.transform.position.z),2);
			Vector3 finalTargetCoord = new Vector3 (target.transform.position.x, target.transform.position.y+25, target.transform.position.z);
			Vector3 halfTargetCoord = new Vector3 (target.transform.position.x, (float)(target.transform.position.y+20+(1/2)*initialDist), target.transform.position.z/2);
			float step = Time.deltaTime * 90;
			if (currentDist >= initialDist / 2) {
				transform.position = Vector3.MoveTowards (transform.position, halfTargetCoord, step);
			} 
			else {
				anim.SetInteger ("PlayerState", 2);
				transform.position = Vector3.MoveTowards (transform.position, finalTargetCoord, step);
			}
			if (transform.position == finalTargetCoord) {
				target.tag = "HomePlanet";
				transform.parent = target.transform;
				target.GetComponent<HomePlanetMove>();
				target = null;
				anim.SetInteger ("PlayerState", 0);
			}
		}

	}

	private GameObject findClosestPlanet(Vector2 touch) 
	// https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html has the original code this method was based off from 
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