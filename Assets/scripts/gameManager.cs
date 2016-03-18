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
	private GameObject[] spawnPoints;

	MouseLock mouse = new MouseLock();

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

	void Update() {
		foreach (int i in playerScores) {
			if (i >= numberOfPlayers) {
				// to change later
				SceneManager.LoadScene(0);
			}
		}
	}

	void InitGame() {
		// change this later! should be an option set in settings
		horizontalSplit = true;
		// delete this later! in for testing
		local = true;
		numberOfPlayers = 0;
	}

	// call this to set the game to be in local mode
	public void LocalSet() {
		local = true;
	}

	public void PlayerCountSet(int players) {
		playerScores = new int[players];
		numberOfPlayers = players;
		SceneManager.LoadScene(1);
		for (int i = 0; i < playerScores.Length; i++) {
			playerScores[i] = 0;
		}
	}

	void CreatePlayers(int players) {
		if (local) {
			FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
			FirstPersonDrifter.playerNum = 0;
			for (int i = 1; i <= numberOfPlayers; i++) {
				FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
				FirstPersonDrifter.playerNum = i;
				Instantiate(player, spawnPoints[i - 1].transform.position, Quaternion.identity);
			}
		}
	}

	public static void ShuffleArray<T>(T[] arr) {
		for (int i = arr.Length - 1; i > 0; i--) {
    	int r = Random.Range(0, i);
    	T tmp = arr[i];
    	arr[i] = arr[r];
    	arr[r] = tmp;
    }
  }

	void OnLevelWasLoaded(int level) {
		if (level > 0) {
			mouse.Lock();
			if (spawnPoints == null) {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        ShuffleArray(spawnPoints);
			}
      Debug.Log("spawnPoints: " + spawnPoints);
			CreatePlayers(numberOfPlayers);
		}
		else {
			mouse.Unlock();
		}
	}

	void OnApplicationQuit() {
		gameObjectsToDestroy = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < gameObjectsToDestroy.Length; i++) {
			Destroy(gameObjectsToDestroy[i]);
		}
	}
}
