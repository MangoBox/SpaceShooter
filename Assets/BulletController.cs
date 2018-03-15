using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyBullet (false));
		activateTrail ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Enemy") {
			Destroy (col.gameObject);

			//GameController.gc.DecKillsLeft ();
		}
		destroyBullet (true);

	}


	IEnumerator destroyBullet(bool now) {
		if(!now) yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);

	}

	IEnumerator activateTrail() {
		yield return new WaitForSeconds (0.1f);
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.enabled = true;
	}

}
