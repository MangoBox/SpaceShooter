using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemGeneration {


}


public class PlanetSystem {
	int numPlanets;
	float planetDist;
	float minScale;
	float maxScale;
	GameObject planet;

	public PlanetSystem(float planetDist, int numPlanets, float minScale, float maxScale) {
		this.planetDist = planetDist;
		this.numPlanets = numPlanets;
		this.minScale = minScale;
		this.maxScale = maxScale;
		this.planet = planet;
	}

	public List<Vector2> generatePlanetLocations() {
		List<Vector2> planets = new List<Vector2> ();
		for(int i = 0; i < numPlanets; i++) {
			float r_ang = Random.Range (0, 2 * Mathf.Rad2Deg * Mathf.PI);
			float x = Mathf.Cos (r_ang) * i * planetDist;
			float y = Mathf.Sin (r_ang) * i * planetDist;
			planets.Add (new Vector2 (x, y));
		}
		return planets;
	}

	/*public void instantiateAll() {
		List<Vector2> pos = generatePlanetLocations ();
		foreach(Vector2 p in pos) {
			GameObject obj = Instantiate (planet);
			obj.transform.position = new Vector3(p.x,p.y,10);
			MeshRenderer mr = obj.GetComponent<MeshRenderer> ();
			mr.material = new Material (planetShader);
			mr.material.color = new Color (Random.value, Random.value, Random.value);
		}

	}*/


}