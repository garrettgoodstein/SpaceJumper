﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
	
	public GameObject planet;
	GameObject planet_clone;

	SpriteRenderer planetRenderer;
	Texture2D[] planetTextures;

	// Use this for initialization
	void Start () {
		planetTextures = new Texture2D[2];
		loadTextures ();

		for (int i = 0; i < 15; i++) {
			createNewPlanet ();
		}

	}


	void Update(){
		if (!planetRenderer.isVisible) {
			//TODO need to fix the destroy method so the object disappears
		}

	}

	//Add a method that creates a new planet so it can be used both in the start and to check if a planet is destroyed

	public void createNewPlanet(){
		//Texture2D blend  = AlphaBlend(Resources.Load("Images/Test2", typeof (Texture2D)) as Texture2D,Resources.Load("Images/Test1", typeof (Texture2D)) as Texture2D);

		Texture2D blend = blendTextures ();

		planet_clone = (GameObject) Instantiate (planet, new Vector3(Random.Range(-800,800), Random.Range(-800,800), Random.Range(1000, 1900)), transform.rotation) as GameObject;
		//planet_clone = (GameObject) Instantiate (planet, new Vector3(40, 40, 1800), transform.rotation) as GameObject;
		planetRenderer = planet_clone.GetComponent<SpriteRenderer> ();
		planetRenderer.sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.0f, 0.0f), 10.0f) as Sprite;
	
	}

	void loadTextures(){
		//LoadAll not getting the images in file and returning as list *need to check documentation*
		//planetTextures = Resources.LoadAll ("PlanetTextures", typeof(Texture2D[])) as Texture2D[];

		planetTextures [0] = Resources.Load ("PlanetTextures/Test2", typeof(Texture2D)) as Texture2D;
		planetTextures [1] = Resources.Load ("PlanetTextures/Test1", typeof(Texture2D)) as Texture2D;
	}

	//Blends Textures together using AlphaBlend and returns the resulting Texture2D object
	Texture2D blendTextures(){
		
		Texture2D baseTexture = planetTextures[0];
		Texture2D layer1Texture = planetTextures[1];
//		Texture2D layer2Texture = planetTextures[Random.Range(0,planetTextures.Length-1)];
//		Texture2D detailTexture = planetTextures[Random.Range(0,planetTextures.Length-1)];;

		return AlphaBlend (baseTexture, layer1Texture);

	}
	
	// Update is called once per frame

	// Having issue where two false values are recorded after start has finished running
	void LateUpdate () {
//		Debug.Log ("Is visible: "+planetRenderer.isVisible);
//		if (!planetRenderer.isVisible) {
//			Destroy (planet_clone);
//			planet_clone = (GameObject) Instantiate (planet, new Vector3(100, 50, 200), transform.rotation) as GameObject;
//			Texture2D blend = AlphaBlend(Resources.Load("Images/Test2", typeof (Texture2D)) as Texture2D,Resources.Load("Images/Test1", typeof (Texture2D)) as Texture2D);
//			planetRenderer.sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.5f, 0.5f), 10.0f) as Sprite;
//			enabled = true;
//		}

	}


	// make sure this code is credited https://answers.unity.com/questions/1008802/merge-multiple-png-images-one-on-top-of-the-other.html
	public static Texture2D AlphaBlend(Texture2D aBottom, Texture2D aTop)
	{
		if (aBottom.width != aTop.width || aBottom.height != aTop.height)
			throw new System.InvalidOperationException("AlphaBlend only works with two equal sized images");
		var bData = aBottom.GetPixels();
		var tData = aTop.GetPixels();
		int count = bData.Length;
		var rData = new Color[count];
		for(int i = 0; i < count; i++)
		{
			Color B = bData[i];
			Color T = tData[i];
			float srcF = T.a;
			float destF = 1f - T.a;
			float alpha = srcF + destF * B.a;
			Color R = (T * srcF + B * B.a * destF)/alpha;
			R.a = alpha;
			rData[i] = R;
		}
		var res = new Texture2D(aTop.width, aTop.height);
		res.SetPixels(rData);
		res.Apply();
		return res;
	}
}
