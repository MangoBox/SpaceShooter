using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public float forceMultipler;
	public Camera mainCamera;
	public ShipJoystick jc;
	private Rigidbody2D body;
	public ParticleSystem booster;
	public GameObject planet;
	public Shader planetShader;
	public int circleSegments;
	public float orbitSpacing;

	public float minScale;
	public float maxScale;

	public Image fuel;
	public Image health;
	public int numPlanets;
	public float rotateForce;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		PlanetSystem ps = new PlanetSystem (orbitSpacing, numPlanets, minScale, maxScale);
		List<Vector2> planets = ps.generatePlanetLocations ();
		lr.SetVertexCount (circleSegments * numPlanets);
		int i = 0;
		foreach(Vector2 p in planets) {
			
			GameObject obj = Instantiate (planet);
			obj.transform.position = new Vector3(p.x,p.y,10);
			obj.transform.localScale = Vector3.one * Random.Range (minScale, maxScale);
			MeshRenderer mr = obj.GetComponent<MeshRenderer> ();
			mr.material = new Material (planetShader);
			mr.material.color = new Color (Random.value, Random.value, Random.value);

			CreatePoints (circleSegments, i++ * orbitSpacing, i);
		}

	}

	void UpdateHealth(float amount) {
		health.fillAmount = amount;

	}

	void UpdateFuel(float amount) {
		fuel.fillAmount = amount;

	}


	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0) {
			foreach(Touch t in Input.touches) {
				//Vector2 dir = new Vector2 (jc.x, jc.y) * forceMultipler;
				Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * forceMultipler;
				print("Ship: " + dir);
				body.AddForce (dir);
				float mag = dir.magnitude;
				var emission = booster.emission;
				emission.rateOverTime = mag;
			}
		}
		//Vector2 dir = new Vector2 (jc.x, jc.y) * forceMultipler;
		Vector2 dir2 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * forceMultipler;
		float rotForce = -Input.GetAxis ("Rotate") * rotateForce;
		body.AddRelativeForce (dir2);
		body.AddTorque (rotForce);
		float mag2 = dir2.magnitude;
		var emission2 = booster.emission;
		emission2.rateOverTime = mag2;
		UpdateHealth (h -= (0.000025f * dir2.magnitude));
	}
	float h = 1f;	


	public LineRenderer lr;
	void CreatePoints (int segments, float r, int circle)
	{
		float x;
		float y;
		float z = 10f;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * r;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * r;

			lr.SetPosition (i + circle * segments ,new Vector3(x,y,z) );
			angle += (360f / segments);
		}
	}
}
