using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float spawnTimer;
	float timeLeft;

	public GameObject enemyShip;
	public GameObject playerShip;

	public Vector2 lowerSpawn;
	public Vector2 upperSpawn;

	public GameObject gameOverScreen;

	public Text killsLeftText;
	public Text finalKills;

	int killsLeft = 0;
	int killCount = 0;

	public static GameController gc;
	public GameObject enemyPrefab;

	public static GameObject getEnemyPrefab {
		get {
			return gc.enemyPrefab;
		}
	}

	// Use this for initialization
	void Start () {
		timeLeft = spawnTimer;
		Time.timeScale = 1;
		gc = this;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			timeLeft = spawnTimer;
			//SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		EnemyController.inst (new Vector2 (Mathf.Lerp (upperSpawn.x, lowerSpawn.x, Random.value), Mathf.Lerp (upperSpawn.y, lowerSpawn.y, Random.value)));
	}

	public void GameOver() {
		gameOverScreen.active = true;
		Time.timeScale = 0f;
		finalKills.text = "Kills: " + killCount;
	}

	public void StartNewGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Scene1");
	}

	public void IncKillsLeft() {
		killsLeft++;
		killsLeftText.text = "Enemies Left: " + killsLeft;
	}

	//Implement gaming winning logic / level advancement
	public void DecKillsLeft() {
		if (killsLeft <= 0) {
			newLevel ();
			return;
		}

		killsLeft--;
		killsLeftText.text = "Enemies Left: " + killsLeft;
	}

	public void newLevel() {
		SceneManager.LoadScene ("Scene1");
	}
}
