using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SpaceWanderer 
// November 5th, 2017
// Team Anhagama 

public class ButtonScript : MonoBehaviour {

	public void LoadScene()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void LoadAbout()
	{
		SceneManager.LoadScene("About");
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("SpaceWandererTestScene");
	}

	public void GameQuit()
	{
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
