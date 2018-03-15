using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject target;
	public Rigidbody2D body;
	public float speed;
	public float trackingDistance;

	void Update() {
		if (Vector3.Distance (target.transform.position, transform.position) < trackingDistance) {
			Vector2 dif = target.transform.position - transform.position;
			body.AddForce (dif * speed);
		}
	}

	static int i =0;

	public static GameObject inst(Vector2 pos) {
		/*GameObject obj = Instantiate (GameController.getEnemyPrefab);
		obj.transform.position = pos;

		EnemyController ec = obj.GetComponent<EnemyController> ();
		ec.target = GameController.gc.gameObject;
		GameController.gc.IncKillsLeft ();
		print (++i);
		return obj;*/
		return null;
	}


}
