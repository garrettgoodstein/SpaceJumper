using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SpaceWanderer 
// November 5th, 2017
// Team Anhagama 

public class ButtonScript : MonoBehaviour {

	public void LoadScene()
	{
		Application.LoadLevel("GameScene");
	}

	public void LoadAbout()
	{
		Application.LoadLevel("About");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
