using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public Rigidbody2D ship;
	public float shipForce;

	public static Vector2 touchPos;

	void Update() {
		if (Input.touchCount > 0) {
			foreach (Touch t in Input.touches) {
				Vector2 pos = t.position;
				Vector2 wPos = Camera.main.ScreenToWorldPoint (pos);
				touchPos = wPos;

			}
		}
	}

}
