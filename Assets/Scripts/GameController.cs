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
		gameOverScreen.SetActive (true);
		Time.timeScale = 0;
	}

	public void StartNewGame(bool newGame) {
		SceneManager.LoadScene ("Scene1");

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

	void Update() {
		currentKm = Camera.main.transform.position.x / 10;
		distanceText.text = (int)(overallKm + currentKm) + "km";
		progressBar.fillAmount = currentKm / 100f;
		if (!currentShip.isOnScreen ()) {
			GameOver ();
		}
		if (currentShip.isCompletedLevel ()) {
			StartNewGame (false);
			overallKm = (int)currentKm;
			galaxy++;
		}
		galaxyText.text = "Galaxy " + galaxy;
	}


	void Start() {
		currentShip = FindObjectOfType<ShipPhysics> ();
		StartGame ();
	}
}
