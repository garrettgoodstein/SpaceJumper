using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {
	private Texture2D[] planetTextures;
	private GameObject[] planets;

	public static GameObject planetGeneration(){
		//haven't got working yet still working through bugs
		//planetTextures = AssetDatabase.LoadAllAssetsAtPath ("Assets/Textures/planetTextures", typeof(Texture2D));
		//planetGeneration();
		planets = new GameObject[planetTextures.Length-1] ();

		for (int i = 0; i < planetTextures.Length - 1; i++) {
			GameObject planet = new GameObject ("planet"); //creates new GameObject
			Texture2D planetT = alphaBlend (planetTextures [i], planetTextures [i + 1]);
			planet.GetComponent<Renderer> ().material.mainTexture = planetT;
			planets [i] = planet;

		}

	}

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
