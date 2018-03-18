/*
 * Liam Davies 2018
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// This class must only be used to control instances of the game during play.
/// Any ship management, main menu or other UI based stuff must be controlled elsewhere.
/// </summary>
public class GameController : MonoBehaviour {

	/// <summary>
	/// The current ship data. Needs to be assigned to before game start.
	/// </summary>
	public static ShipData currentShipData;
	/// <summary>
	/// The current ship. Should be assigned to when the game starts, by instantiating ship.
	/// </summary>
	public static ShipPhysics currentShip;

	public GameObject gameOverScreen;

	//ACCESSOR FIELDS
	public LevelGenerator lc {
		get {
			return GetComponent<LevelGenerator> ();
		}
	}


	/// <summary>
	/// To be called to start the game.
	/// </summary>
	public void StartGame() {
		Time.timeScale = 1;
		lc.GenerateLevel (20,  10, 1000);

	}

	public void GameOver() {
		currentKm = 0;
		overallKm = 0;
		gameOverScreen.SetActive (true);
		Time.timeScale = 0;
		gameOverAnimation.SetTrigger("GameOverEntry");
	}

	public void StartNewGame() {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Scene1");
	}

	public void NextGalaxy() {
		SceneManager.LoadScene ("Scene1");
		galaxy++;
		overallKm += (int)currentKm;
		//currentShip.travellingSpeed *= 1.5f;
	}


	//TEMP CODE
	//Remove everything here


	[Header("Temporary Fields")]
	public Text distanceText;
	public GameObject distanceTracker;
	public float distanceMultiplier;
	public Image progressBar;
	public Text galaxyText;

	static int overallKm = 0;
	static int galaxy = 1;
	float currentKm = 0;
	public Animator gameOverAnimation;
	public SpriteRenderer background;

	void Update() {
		currentKm = Camera.main.transform.position.x / 10;
		distanceText.text = (int)(overallKm + currentKm) + "km";
		progressBar.fillAmount = currentKm / 100f;
		if (!currentShip.isOnScreen ()) {
			GameOver ();
		}
		if (currentShip.isCompletedLevel ()) {
			NextGalaxy();
		}
		background.size += Vector2.right * 0.025f;
	}

	void Start() {
		currentShip = FindObjectOfType<ShipPhysics> ();
		StartGame ();
		galaxyText.text = "Galaxy " + galaxy;
	}
}
