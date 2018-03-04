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
		t.position = Vector3.Lerp (t.position, target.position, 0.4f) + new Vector3(0,0,-10);
	}
}
