using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static gameManager m = null;

	public int[] playerScores;
	public int numberOfPlayers;

	public bool local;
	public bool horizontalSplit;

	public GameObject player;
	GameObject[] gameObjectsToDestroy;

	private FirstPersonDrifter FirstPersonDrifter;

	void Awake() {
		if (m == null) {
			m = this;
		}
		else if (m != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	void InitGame() {
		// change this later! should be an option set in settings
		horizontalSplit = true;
		// delete this later! in for testing
		local = true;
		numberOfPlayers = 0;

		// remove this later, purely for debug testing
		// PlayerCountSet(numberOfPlayers);
	}

	// call this to set the game to be in local mode
	public void LocalSet() {
		local = true;
	}

	public void PlayerCountSet(int players) {
		playerScores = new int[players];
		numberOfPlayers = players;
		SceneManager.LoadScene(1);
	}

	void CreatePlayers(int players) {
		if (local) {
			FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
			FirstPersonDrifter.playerNum = 0;
			for (int i = 1; i <= numberOfPlayers; i++) {
				// change the vector3 values later!
				// randomized from an array of empty gameobjects most likely
				FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
				FirstPersonDrifter.playerNum = i;
				Instantiate(player, new Vector3(i, i, 0), Quaternion.identity);
				
				Debug.Log("current loop num is: " + i);
				
				Debug.Log("applied playernum is: " + FirstPersonDrifter.playerNum);
			}
		}
	}

	void OnLevelWasLoaded(int level) {
		if (level > 0) {
			CreatePlayers(numberOfPlayers);
		}
	}

	void OnApplicationQuit() {
		gameObjectsToDestroy = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < gameObjectsToDestroy.Length; i++) {
			Destroy(gameObjectsToDestroy[i]);
		}
	}
}
