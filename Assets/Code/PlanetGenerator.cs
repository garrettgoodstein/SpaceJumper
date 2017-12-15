using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {

	public GameObject planet;
	GameObject planet_clone;

    Texture2D[] solids;
	Texture2D[] overlays;

	public Sprite[] solidSprites;
	public Sprite[] overlaySprites;

	GameObject prince;
	Transform princeTransform;

	Camera camera;

	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>() ;

		loadTextures ();

		solidSprites = createSpriteList (solids);
		overlaySprites = createSpriteList (overlays);

		for (int i = 0; i <15; i++) {
			createNewPlanet ();
		}
	}

	void createNewPlanet(){
		float randZ = Random.Range (700, 1200);

		float frustumH = calculateFrustumHeight(randZ);
		float frustumW = calculateFrustumWidth (randZ, frustumH);

		int xRange = (int)frustumW / 2;
		int yRange = (int)frustumH / 2;

		float randX = Random.Range (-xRange, xRange);
		float randY = Random.Range (-yRange, yRange);

		planet_clone = (GameObject)Instantiate (planet, new Vector3 (randX, randY , randZ), transform.rotation) as GameObject;
		planet_clone.tag = "Planet";

		composePlanet (planet_clone);
		setPlanetRenderOrder (planet_clone);
	}

	public int calculateHeightRange(float zPos){
		return (int)(calculateFrustumHeight (zPos) / 2);
	}

	public int calculateWidthRange(float zPos){
		float fHeight = calculateFrustumHeight (zPos);
		return (int)(calculateFrustumWidth (zPos, fHeight) / 2);
	}

	float calculateFrustumHeight(float distance){
		return 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
	}

	float calculateFrustumWidth(float distance, float frustumHeight){
		return frustumHeight * camera.aspect;
	}

	public void composePlanet(GameObject planet){
		if (planet.transform.childCount > 0) {
			for (int i = planet.transform.childCount-1; i >= 0; i--) {
				Destroy (planet.transform.GetChild (i).gameObject);
			}
		}
		addLayerAsChild (planet, solidSprites);
		addLayerAsChild (planet, overlaySprites);
		addLayerAsChild (planet, overlaySprites);
		addLayerAsChild (planet, overlaySprites);
	}

	void loadTextures(){
		solids = Resources.LoadAll<Texture2D> ("PlanetTextures/Solids");
		overlays = Resources.LoadAll<Texture2D> ("PlanetTextures/Overlays");
	}
		
	void addLayerAsChild(GameObject parent, Sprite[] spriteList){
		GameObject child = new GameObject ();
		child.transform.SetParent (parent.transform, false);
		child.transform.localPosition = Vector3.zero;

		SpriteRenderer childSR = child.AddComponent<SpriteRenderer> ();

		assignLayer (child, spriteList);
	}

	public void assignLayer(GameObject child, Sprite[] sprites){
		child.GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, sprites.Length)];
		addSpinToLayer (child);
	}

	Sprite[] createSpriteList(Texture2D[] textures){
		Sprite[] sprites = new Sprite[textures.Length];

		for(int i = 0;i < sprites.Length;i++) {
			Texture2D texture = textures [i];
			sprites[i] = Sprite.Create (texture, new Rect (0.0f, 0.0f, texture.width, texture.height), new Vector2 (0.5f, 0.5f), 5.0f) as Sprite;
		}
		return sprites;
	}

	void addSpinToLayer(GameObject child){
		if (child.GetComponent<Spin> () == null) {
			Spin spin = child.AddComponent<Spin> ();
			spin.speed = Random.Range (-10, 10);
			spin.axis = Vector3.forward;
		}
	}

	public void setPlanetRenderOrder(GameObject planet){
		SpriteRenderer parentRenderer = planet.GetComponent<SpriteRenderer> ();

		int parentRenderOrder = ((int)planet.transform.position.z%2000);
		parentRenderer.sortingOrder = parentRenderOrder;

		for (int i = 0; i < planet.transform.childCount; i++) {
			setChildRenderOrder (parentRenderOrder, planet.transform.GetChild (i).GetComponent<SpriteRenderer> (), i);
		}

	}

	void setChildRenderOrder(int parentRenderOrder, SpriteRenderer childSR, int childNum){
		childSR.sortingOrder = parentRenderOrder + childNum;
	}

}
