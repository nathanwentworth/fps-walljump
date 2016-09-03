using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static gameManager m = null;

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

	private int numberOfPlayers;

	public int NumberOfPlayers {
		get {return numberOfPlayers;}
	}


	public bool local;
	public bool horizontalSplit;

	public GameObject player;
	public GameObject menuCanvasContainers;
	GameObject[] gameObjectsToDestroy;

	private FirstPersonDrifter FirstPersonDrifter;
	private GameObject[] spawnPoints;
	private int currentScene;

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

		currentScene = SceneManager.GetActiveScene().buildIndex;
	}

	void InitGame() {
		// change this later! should be an option set in settings
		horizontalSplit = true;
		// delete this later! in for testing
		local = true;
		// numberOfPlayers = 1;
	}

	// call this to set the game to be in local mode
	public void LocalSet() {
		local = true;
	}

	// function is called in the main menu ui
	// this:
	// * sets the number of players, creates a score array in that size
	// * runs the animation to move the menu down
	public void PlayerCountSet(int players) {
		playerScores = new int[players];
		playerStatus = new int[players];
		numberOfPlayers = players;
		for (int i = 0; i < playerScores.Length; i++) {
			playerScores[i] = 0;
			playerStatus[i] = 1;
		}
		if (currentScene == 0) {
			if (menuCanvasContainers != null) {
				Animator anim;
				anim = menuCanvasContainers.GetComponent<Animator>();
				anim.SetBool("open", true);
			}
		} 
	}

	public void LevelSelectSet(int level) {
		SceneManager.LoadScene(level);
	}

	void CreatePlayers(int players) {
		if (local) {
			// FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
			// FirstPersonDrifter.playerNum = 0;
			for (int i = 1; i <= numberOfPlayers; i++) {
				FirstPersonDrifter = player.GetComponent<FirstPersonDrifter>();
				FirstPersonDrifter.playerNum = i;
				Instantiate(player, spawnPoints[i - 1].transform.position, Quaternion.identity);
				print("Created player " + i);
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
