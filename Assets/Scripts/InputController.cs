using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public Rigidbody2D ship;
	public float shipForce;

	public static Vector2 touchPos;
	Vector2 lastTouchPos;

	void Update() {
		if (Input.touchCount > 0) {
			foreach (Touch t in Input.touches) {
				lastTouchPos = t.position;
			}
		}

		touchPos = new Vector2 (Camera.main.transform.position.x, Camera.main.ScreenToWorldPoint (lastTouchPos).y);
	}

	public static bool touching;

	/*void Update() {
		if (Input.touchCount > 0) {
			touching = true;
		} else {
			touching = false;
		}
	}*/

}
