/*
 * Liam Davies 2018
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class must only be used to control instances of the game during play.
/// Any ship management, main menu or other UI based stuff must be controlled elsewhere.
/// </summary>
public class GameController : MonoBehaviour {

	/// <summary>
	/// The current ship data. Needs to be assigned to before game start.
	/// </summary>
	public static ShipData currentShipData;

	//ACCESSOR FIELDS
	public PlanetController pc {
		get {
			return GetComponent<PlanetController> ();
		}
	}


	/// <summary>
	/// To be called to start the game.
	/// </summary>
	public void StartGame() {
		for (int i = 0; i < 25; i++) {
			pc.SpawnPlanet (new Vector2 (Random.value * 1000, Random.value * 10));
		}
	}

	//TEMP CODE
	//Remove everything here

	void Start() {
		StartGame ();
	}
}
