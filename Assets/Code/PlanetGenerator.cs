using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
	
	public GameObject planet;
	GameObject planet_clone;

	SpriteRenderer planetRenderer;
	Texture2D[] planetTextures;

	bool visible;

	// Use this for initialization
	void Start () {
		planetTextures = new Texture2D[6];
		visible = true;
		loadTextures ();

		for (int i = 0; i < 15; i++) {
			createNewPlanet ();

		}
	}
	public void createNewPlanet(){
		Texture2D blend = blendTextures ();

		planet_clone = (GameObject)Instantiate (planet, new Vector3 (Random.Range (-800, 800), Random.Range (-800, 800), Random.Range (800, 1900)), transform.rotation) as GameObject;
		planet_clone = (GameObject) Instantiate (planet, new Vector3(40, 40, 1800), transform.rotation) as GameObject;

		planetRenderer = planet_clone.GetComponent<SpriteRenderer> ();
		planetRenderer.sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.0f, 0.0f), 10.0f) as Sprite;
		planet_clone.tag = "Planet";
	}

	void loadTextures(){
		//LoadAll not getting the images in file and returning as list *need to check documentation*
		//planetTextures = Resources.LoadAll ("PlanetTextures", typeof(Texture2D[])) as Texture2D[];

		planetTextures [0] = Resources.Load ("PlanetTextures/Solids/brownSolidTexture1", typeof(Texture2D)) as Texture2D;
		planetTextures [1] = Resources.Load ("PlanetTextures/Textures/blueTexture1", typeof(Texture2D)) as Texture2D;
		planetTextures [2] = Resources.Load ("PlanetTextures/Textures/blueTexture2", typeof(Texture2D)) as Texture2D;
		planetTextures [3] = Resources.Load ("PlanetTextures/Textures/purpleTexture1", typeof(Texture2D)) as Texture2D;
		planetTextures [4] = Resources.Load ("PlanetTextures/Textures/purpleTexture2", typeof(Texture2D)) as Texture2D;
		planetTextures [5] = Resources.Load ("PlanetTextures/Textures/yellowTexture", typeof(Texture2D)) as Texture2D;

		// loading images
		// planetTextures [6] = Resources.Load ("PlanetTextures/brownSolidTexture1", typeof(Texture2D)) as Texture2D;
		// planetTextures [7] = Resources.Load ("PlanetTextures/blueTexture1", typeof(Texture2D)) as Texture2D;
		// planetTextures [8] = Resources.Load ("PlanetTextures/blueTexture2", typeof(Texture2D)) as Texture2D;
		// planetTextures [9] = Resources.Load ("PlanetTextures/purpleTexture1", typeof(Texture2D)) as Texture2D;
		// planetTextures [10] = Resources.Load ("PlanetTextures/purpleTexture2", typeof(Texture2D)) as Texture2D;
		// planetTextures [11] = Resources.Load ("PlanetTextures/yellowTexture", typeof(Texture2D)) as Texture2D;
	}

	//Blends Textures together using AlphaBlend and returns the resulting Texture2D object
	Texture2D blendTextures(){
		
		Texture2D baseTexture = planetTextures[Random.Range(0,4)];
		Texture2D layer1Texture = planetTextures[Random.Range(2, 6)];
//		Texture2D layer2Texture = planetTextures[Random.Range(0,planetTextures.Length-1)];
//		Texture2D detailTexture = planetTextures[Random.Range(0,planetTextures.Length-1)];;

		return AlphaBlend (baseTexture, layer1Texture);

	}
	
//	// Update is called once per frame
//	void LateUpdate(){
//		if (!planetRenderer.isVisible) {
//			relocate ();
//		}
//	}
//
//	void relocate(){
////		Texture2D blend = blendTextures ();
////		planetRenderer.sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.0f, 0.0f), 10.0f) as Sprite;
//
//		// TODO: need to see if the position of the planet can be modified without using translate or addforce
//		// doesn't work
//		transform.position = new Vector3 (Random.Range (-800, 800), Random.Range (-800, 800), Random.Range (200, 500));
//
//	}



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
