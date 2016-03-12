using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager m = null;

	public int[] playerScores;
	public int numberOfPlayers;

	public bool local;
	public bool horizontalSplit;

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
	}

	// call this to set the game to be in local mode
	public void LocalSet() {
		local = true;
	}

	public void PlayerCountSet(int players) {
		playerScores = new int[players];
		numberOfPlayers = players;
		CreatePlayers(players);
	}

	void CreatePlayers(int players) {
		if (local) {
			if (horizontalSplit) {
				switch (players) {
					case 1:
						break;
					case 2:
						break;
					case 3:
						break;
					case 4:
						break;
				}
			}
		}
	}
}
