using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour {
	public GameManager gm;
	MouseLock mouse = new MouseLock();

	void Start() {
		mouse.Unlock();
	}

	public void PlayerCountSet(int players) {
		gm.PlayerScores = new int[players];
		gm.PlayerStatus = new int[players];
		gm.NumberOfPlayers = players;
		for (int i = 0; i < gm.PlayerScores.Length; i++) {
			gm.PlayerScores[i] = 0;
			gm.PlayerStatus[i] = 1;
		}
		Animator anim;
		anim = GetComponent<Animator>();
		anim.SetBool("open", true);
	}

	public void LevelSelectSet(int level) {
		SceneManager.LoadScene(level);
	}
}
