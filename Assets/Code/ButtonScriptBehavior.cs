using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SpaceWanderer 
// November 5th, 2017
// Team Anhagama 
// This class allows button to have behavior that would allow them to load certain scenes by text. 

public class ButtonScriptBehavior : MonoBehaviour {

	public void LoadScenes(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
