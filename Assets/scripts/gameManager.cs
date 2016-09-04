using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName="Game Manager", menuName="", order = 1)]
public class GameManager : ScriptableObject {

	private int[] playerScores;

	public int[] PlayerScores {
		get {return playerScores;}
		set {playerScores = value;}
	}

	[SerializeField]
	private int[] playerStatus;

	public int[] PlayerStatus {
		get {return playerStatus;}
		set {playerStatus = value;}
	}

	[SerializeField]
	private int numberOfPlayers;

	public int NumberOfPlayers {
		get {return numberOfPlayers;}
		set {numberOfPlayers = value;}
	}

	public GameObject player;
	public GameObject winnerCanvas;
	private Text winnerText;
	GameObject[] gameObjectsToDestroy;

	private FirstPersonDrifter FirstPersonDrifter;
	private GameObject[] spawnPoints;

	public GameObject[] SpawnPoints {
		get {return spawnPoints;}
		set {spawnPoints = value;}
	}


	private int currentScene;

	public int CurrentScene {
		get {return currentScene;}
	}

	void Awake() {
		currentScene = SceneManager.GetActiveScene().buildIndex;
	}

	public void LevelSelectSet(int level) {
		SceneManager.LoadScene(level);
	}

	void OnApplicationQuit() {
		gameObjectsToDestroy = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < gameObjectsToDestroy.Length; i++) {
			Destroy(gameObjectsToDestroy[i]);
		}
	}
}
