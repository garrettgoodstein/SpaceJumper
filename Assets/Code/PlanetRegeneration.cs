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
		float randZ = Random.Range (450, 500);
		float zPos = princeOffset + randZ;

		float yRange = generatorScript.calculateHeightRange (randZ);
		float xRange = generatorScript.calculateWidthRange (randZ);

		transform.position = new Vector3 (Random.Range(-xRange,xRange), Random.Range(-yRange, yRange), zPos);
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
