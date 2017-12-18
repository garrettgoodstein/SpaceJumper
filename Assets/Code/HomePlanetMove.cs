using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanetMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sortingOrder = 10000;
		PlanetGenerator generatorScript = GameObject.FindGameObjectWithTag ("Planet").GetComponent<PlanetGenerator> ();
		for (int i = 0; i < transform.childCount; i++) {
			generatorScript.setChildRenderOrder (10000, transform.GetChild (i).GetComponent<SpriteRenderer> (), i);
		}
	}


	void Update () {
		float step = Time.deltaTime * 20;
		transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x,transform.position.y,transform.position.z + 5), step);
		
	}
}
