using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInstance : MonoBehaviour {

	public SpriteRenderer planetCore;
	public SpriteRenderer planetBackFoilage;
	public SpriteRenderer planetUpperFoilage;
	public SpriteRenderer planetLowerFoilage;

	public Shader planetShader;

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
	}


	void Update() {
		transform.Rotate(new Vector3 (0, 0, rotateSpeed));
	}
}
