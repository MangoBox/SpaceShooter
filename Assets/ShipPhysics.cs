using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPhysics : MonoBehaviour {


	Rigidbody2D body;


	[Header("Ship Data")]
	//Revamped data
	public float accelerationMultipler;
	public float speedMultipler;

	public ShipType shipType;

	[Header("Handling Physics")]
	public float rotateForce = 4;
	public float rotateRevertForce = 1;
	public float agility = 1;
	public float directionCorrectForce = 1;

	[Header("World Physics")]
	public float travellingSpeed;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate() {
		//Constant forwards motion
		body.AddForce(transform.right * travellingSpeed);

		Vector3 force = (InputController.touchPos - (Vector2)transform.position) * agility;
		body.AddForce (force);
		body.AddTorque (Vector2.Dot (transform.TransformDirection(Vector2.up), body.velocity) * directionCorrectForce);
	}

	public bool isOnScreen() {
		float x = Camera.main.ScreenToWorldPoint (Vector3.zero).x;
		return transform.position.x > x;
	}

	public bool isCompletedLevel() {
		return transform.position.x > 1000;
	}
}
