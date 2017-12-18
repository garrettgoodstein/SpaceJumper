using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRegeneration : MonoBehaviour {

	bool hasEverBeenVisible;

	float fadingInSpeed;
	float alphaValue;

	SpriteRenderer sr;

	PlanetGenerator generatorScript;

	GameObject prince;
	Transform princeTransform;
	float princeOffset;



	// Use this for initialization
	void Start () {
		fadingInSpeed = 10f;
		alphaValue = 1f;

		hasEverBeenVisible = false;

		sr = gameObject.GetComponent<SpriteRenderer> ();

		prince = GameObject.FindGameObjectWithTag ("Prince");
		princeTransform = prince.GetComponent<Transform> ();
		princeOffset = 0;

		generatorScript = GameObject.FindGameObjectWithTag ("Planet").GetComponent<PlanetGenerator> ();

	}
		
	void Update(){
		princeOffset = princeTransform.position.z;
		if (hasEverBeenVisible && !anyChildrenAreVisible()) {
			relocate ();
			for (int i = 0; i < transform.childCount; i++) {
				if (i == 0) {
					generatorScript.assignLayer (transform.GetChild (i).gameObject, generatorScript.solidSprites);
				} else {
					generatorScript.assignLayer (transform.GetChild (i).gameObject, generatorScript.overlaySprites);
				}
			}
//			alphaValue = 1f;
//			fadeIn ();
		}
	}

	void relocate(){
		float zRand = Random.Range (600, 650);
		float zPos = princeOffset + zRand;

		float xRange = generatorScript.calculateWidthRange (zRand);
		float xRand = Random.Range (-xRange, xRange);
		float xPos = xRand + princeTransform.position.x;

		float yRange = generatorScript.calculateHeightRange (zRand);
		float yRand = Random.Range (-yRange, yRange);
		float yPos = yRand + princeTransform.position.y;

		Debug.Log ("prince pos x: " + princeTransform.position.x + " y: " + princeTransform.position.y);

		Debug.Log ("planet pos x: " + xPos + " y: " + yPos);


		transform.position = new Vector3 (xPos, yPos, zPos);
		generatorScript.setPlanetRenderOrder (gameObject);
	}

	bool anyChildrenAreVisible() {
		foreach(Renderer renderer in sr.GetComponentsInChildren<Renderer>()) {
			if(renderer.isVisible)
				return true;
		}
		return false;
	}
		


	void OnBecameVisible() {
		hasEverBeenVisible = true;
	}

	void fadeIn(){
		Debug.Log ("Fading In");
		while (alphaValue >= 0) {
			foreach (SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>()) {
				Color newColor = r.material.color;
				newColor.a = alphaValue;

				r.material.SetColor ("_Color", newColor);
				alphaValue -= Time.deltaTime * fadingInSpeed;
				Debug.Log(alphaValue);
			}
		}
	
	}
		
}
