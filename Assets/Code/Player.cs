using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D _myRigidbody;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		_myRigidbody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
	 {
	 	float move = Input.GetAxis("Horizontal");
		//call current velocity = new velocity
		_myRigidbody.velocity = new Vector2(move*speed, _myRigidbody.velocity.y);


	}
}
