using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	public SpriteRenderer planetCore;
	public SpriteRenderer planetBackFoilage;
	public SpriteRenderer planetUpperFoilage;
	public SpriteRenderer planetLowerFoilage;

	public Shader planetShader;

	public int enemiesToSpawn;
	public float enemyHeight;
	public GameObject enemy;

	public float rotateSpeed;

	void Start() {
		//Planet Core
		planetCore.color = new Color (Random.value, Random.value, Random.value);

		//Planet Core
		planetBackFoilage.color = new Color (Random.value, Random.value, Random.value);
		//Planet Core
		planetUpperFoilage.color = new Color (Random.value, Random.value, Random.value);

		//Planet Core
		planetLowerFoilage.color = new Color (Random.value, Random.value, Random.value);

		transform.Rotate(new Vector3(0,0,Random.Range(0,360)));
		SpawnEnemies ();
	}


	void Update() {
		transform.Rotate(new Vector3 (0, 0, rotateSpeed));
	}


	void SpawnEnemies() {
		for (int i = 0; i < enemiesToSpawn; i++) {
			float theta = Random.value * 2 * Mathf.PI;

			float x = Mathf.Cos (theta) * enemyHeight;
			float y = Mathf.Sin (theta) * enemyHeight;

			EnemyController.inst (transform.position + new Vector3 (x, y));

		}

	}
}
