using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanetMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float step = Time.deltaTime * 25;
		var princePosition = GameObject.FindGameObjectWithTag("Prince");
//		transform.position = Vector3.MoveTowards (transform.position, new Vector3(princePosition.transform.position.x,princePosition.transform.position.y,transform.position.z), step);

		transform.position = Vector3.MoveTowards (transform.position, new Vector3(0,0,-(transform.position.z + 5)), step);
		
	}
}
