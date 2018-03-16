using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject planetPrefab;

	public void GenerateLevel(int count, float height, float width) {
		for (int i = 0; i < count; i++) {
			Vector2 pos = new Vector2 (Random.value * width, (Random.value * height) - height / 2);
			GameObject planet = Instantiate (planetPrefab);
			planet.transform.position = pos;

		}
	}
}
