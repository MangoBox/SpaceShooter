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
	public float rotateForce = 1;
	public float rotateRevertForce = 1;
	public float agility = 1;

	[Header("World Physics")]
	public float travellingSpeed;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate() {
		//Constant forwards motion
		body.AddForce(Vector2.right * travellingSpeed);

		Vector3 force = InputController.touchPos - (Vector2)transform.position;
		body.AddForce (force * agility);
		body.AddTorque (Vector2.Dot (transform.TransformDirection(Vector2.up), force) * rotateForce);
	}
}
