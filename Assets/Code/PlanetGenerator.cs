using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
	public GameObject planet;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 1; i++) {
			//instantiates a planet with random position vector
			//need to play around with ranges for vector instantiation
//			
//			GameObject planet_clone = (GameObject) Instantiate (planet, new Vector3(Random.Range(-100,100), Random.Range(-100,100), Random.Range(50, 800)), transform.rotation) as GameObject;

//			if (i%2 == 0) {
//				planet_clone.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Images/Planet1_tosend", typeof (Sprite)) as Sprite;
//			}
			//Use Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit = 100.0f, 
			//  uint extrude = 0, SpriteMeshType meshType = SpriteMeshType.Tight, Vector4 border = Vector4.zero)
			// use the AlphaBlend method to get the new texture

			Texture2D blend = AlphaBlend(Resources.Load("Images/Test2", typeof (Texture2D)) as Texture2D,Resources.Load("Images/Test1", typeof (Texture2D)) as Texture2D);
			GameObject planet_clone = (GameObject) Instantiate (planet, new Vector3(0, 0, 100), transform.rotation) as GameObject;
			planet_clone.GetComponent<SpriteRenderer> ().sprite = Sprite.Create(blend, new Rect(0.0f, 0.0f, blend.width, blend.height), new Vector2(0.5f, 0.5f), 10.0f) as Sprite;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
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
