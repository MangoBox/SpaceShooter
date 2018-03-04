using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public float forceMultipler;
	public Camera mainCamera;
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
	public float rotateRevertForce;

	public float cameraMinView;
	public float cameraMaxView;
	public float minCameraDistSpeed;
	public float maxCameraDistSpeed;

	public GameController gc;
	public GameObject bullet;

	public float healthDmgAmount;
	public float fuelDrainSpeed;
	public float bulletForce;

	public float bulletDelay;
	float currentBulletDelay;
	bool canShoot {
		get { 
			return currentBulletDelay <= 0;
		}

	}


	public UnityStandardAssets.CrossPlatformInput.Joystick js;
	public UnityStandardAssets.CrossPlatformInput.Joystick shootingJs;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		PlanetSystem ps = new PlanetSystem (orbitSpacing, numPlanets, minScale, maxScale);
		List<Vector2> planets = ps.generatePlanetLocations ();
		lr.SetVertexCount (circleSegments * numPlanets);
		int i = -1;
		foreach(Vector2 p in planets) {
			
			GameObject obj = Instantiate (planet);
			obj.transform.position = new Vector3(p.x,p.y,10);
			obj.transform.localScale = Vector3.one * Random.Range (minScale, maxScale);
			MeshRenderer mr = obj.GetComponent<MeshRenderer> ();

			CreatePoints (circleSegments, i++ * orbitSpacing, i);
		}

	}

	void UpdateHealth(float amount) {
		health.fillAmount = amount;

	}

	void UpdateFuel(float amount) {
		fuel.fillAmount = amount;

	}

	float h = 1f;

	void OnCollisionEnter2D(Collision2D col) {
		float str = col.relativeVelocity.magnitude;
		h -= str * healthDmgAmount;
		health.fillAmount = h;
	}


	// Update is called once per frame
	void Update () {
		

		//Vector2 dir = new Vector2 (jc.x, jc.y) * forceMultipler;
		Vector2 dir2 = new Vector2(js.x, js.y) * forceMultipler;
		body.AddForce (dir2);
		if (dir2.sqrMagnitude == 0) {
			body.AddTorque (Vector2.Dot (Vector2.right, transform.up) * rotateRevertForce);
		} else {
			body.AddTorque (Vector2.Dot (transform.TransformDirection(Vector2.up), dir2) * rotateForce);
		}

		float camView = Mathf.Lerp(cameraMinView, cameraMaxView, Mathf.InverseLerp (minCameraDistSpeed, maxCameraDistSpeed, body.velocity.magnitude));
		mainCamera.orthographicSize = camView;
		var emission2 = booster.emission;
		emission2.rateOverTime = body.velocity.magnitude;
		UpdateFuel (f -= (fuelDrainSpeed * dir2.magnitude));

		if (f <= 0 || h <= 0) {
			gc.GameOver ();
		}
		Vector2 shootingVec = new Vector2 (shootingJs.x, shootingJs.y);
		if (shootingVec.sqrMagnitude != 0 && canShoot) {
			resetShootingDelay ();
			Shoot ();
		}
		currentBulletDelay = Mathf.Clamp (currentBulletDelay - Time.deltaTime, 0, bulletDelay);
	}
	float f = 1f;	


	public LineRenderer lr;
	void CreatePoints (int segments, float r, int circle)
	{
		float x;
		float y;
		float z = 10f;

		float angle = 20f;

		for (int i = 0; i < segments; i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * r;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * r;
			lr.SetPosition (i + (circle * segments),new Vector3(x,y,z) );
			angle += (360f / segments);
		}
	}

	void resetShootingDelay() {
		currentBulletDelay = bulletDelay;
	}

	void Shoot() {
		GameObject bul = Instantiate (bullet);
		float x = shootingJs.x, y = shootingJs.y;
		bul.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (x, y) * bulletForce);
		bul.transform.position = transform.position;
		bul.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Mathf.Atan2(y,x) * Mathf.Rad2Deg));
	}
}
