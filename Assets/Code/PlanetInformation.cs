using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInformation : MonoBehaviour {
	//Script for Holding Information About Planets
	private static int PLANETS_ON_SCREEN = 10;
	GameObject[] planets;

	// Use this for initialization
	void Start () {
		planets = new GameObject[PLANETS_ON_SCREEN];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
