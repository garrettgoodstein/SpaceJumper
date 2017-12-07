﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// SpaceWanderer 
// November 5th, 2017
// Team Anhagama 
// This class allows button to have behavior that would allow them to load certain scenes by text. 

public class ButtonScriptBehavior : MonoBehaviour {

	public Button RestartButton;

	public void Restart(string sceneName)
	{
		GameObject.FindWithTag ("RestartButton").GetComponentInChildren<Text> ().text = "Loading...";
		SceneManager.LoadScene (sceneName);
	}
}


