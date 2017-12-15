using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRegeneration : MonoBehaviour {

	bool hasEverBeenVisible;

	SpriteRenderer sr;

	PlanetGenerator generatorScript;

	GameObject prince;
	Transform princeTransform;
	float princeOffset;



	// Use this for initialization
	void Start () {

		hasEverBeenVisible = false;

		sr = gameObject.GetComponent<SpriteRenderer> ();

		prince = GameObject.FindGameObjectWithTag ("Prince");
		princeTransform = prince.GetComponent<Transform> ();
		princeOffset = 0;

		generatorScript = GameObject.FindGameObjectWithTag ("Planet").GetComponent<PlanetGenerator> ();

	}
		
	void LateUpdate(){
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
		}
	}

	bool anyChildrenAreVisible() {
		foreach(Renderer renderer in sr.GetComponentsInChildren<Renderer>()) {
			if(renderer.isVisible)
				return true;
		}
		return false;
	}
		
	void relocate(){
		float randZ = Random.Range (1500, 1900);
		float zPos = princeOffset + randZ;

		float yRange = generatorScript.calculateHeightRange (randZ);
		float xRange = generatorScript.calculateWidthRange (randZ);

		transform.position = new Vector3 (Random.Range(-xRange,xRange), Random.Range(-yRange, yRange), zPos);
		generatorScript.setPlanetRenderOrder (gameObject);
	}

	void OnBecameVisible() {
		hasEverBeenVisible = true;
	}
		
}
