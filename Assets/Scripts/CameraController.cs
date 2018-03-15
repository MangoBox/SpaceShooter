using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float speed;
	private Transform t {
		get {
			return this.transform;
		}
	}

	public void FixedUpdate() {

		Vector3 cameraPos = new Vector3 (target.position.x + 5, 0, target.position.z);
		t.position = Vector3.Lerp (t.position, cameraPos, 0.4f) + new Vector3(0,0,-10);
	}
}
