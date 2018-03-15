using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	public GameObject planetPrefab;

	public  void SpawnPlanet(Vector2 pos) {
		GameObject planet = Instantiate (planetPrefab);
		planet.transform.position = pos;
	}
}
