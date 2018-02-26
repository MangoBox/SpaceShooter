using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float forceMultipler;
	public Camera mainCamera;
	public ShipJoystick jc;
	private Rigidbody2D body;
	public ParticleSystem booster;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0) {
			foreach(Touch t in Input.touches) {
				Vector2 dir = new Vector2 (jc.x, jc.y) * forceMultipler;
				body.AddForce (dir);
				float mag = dir.magnitude;
				var emission = booster.emission;
				emission.rateOverTime = mag;
			}
		}

	}
}
