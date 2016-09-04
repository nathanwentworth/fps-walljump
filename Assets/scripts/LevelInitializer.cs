using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInitializer : MonoBehaviour {

	public GameManager gm;
	private FirstPersonDrifter FirstPersonDrifter;
	MouseLock mouse = new MouseLock();
	private GameObject[] spawnPoints;

	public Text winnerText;
	public GameObject winnerCanvas;

	private int currentScene;

	void Start () {
		currentScene = SceneManager.GetActiveScene().buildIndex;
		print ("Level loaded.");
		Init();
	}

	void Init() {
		print("Initializing game.");
		print("Currently in scene #" + currentScene);
 		if (currentScene > 0) {
			mouse.Lock();
			print ("Mouse locked.");
			if (spawnPoints == null) {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        ShuffleArray(spawnPoints);
        print ("Found spawn points.");
			}
			CreatePlayers(gm.NumberOfPlayers);
			gm.SpawnPoints = spawnPoints;
		} else {
			mouse.Unlock();
		}

		winnerText.text = "";
	}

	void CreatePlayers(int players) {
		if (spawnPoints.Length > 0) {
			for (int i = 1; i <= players; i++) {
				FirstPersonDrifter = gm.player.GetComponent<FirstPersonDrifter>();
				FirstPersonDrifter.playerNum = i;
				Instantiate(gm.player, spawnPoints[i - 1].transform.position, Quaternion.identity);
			}
			print("Created " + players + " players.");
		} else {
			print ("Can't find any spawn points");
		}
	}

  public void CheckWinStatus() {
    int n = 0;
    for (int status = 0; status < gm.PlayerStatus.Length; status++) {
      if (gm.PlayerStatus[status] == 1) {
        n++;
      }
    }
    if (n == 1) {
      for (int status = 0; status < gm.PlayerStatus.Length; status++) {
        if (gm.PlayerStatus[status] == 1) {
          Debug.Log ("congrats, player " + status + " wins!");
          StartCoroutine(WinnerDisp(status));
        }
      }
    }
  }


  public IEnumerator WinnerDisp(int winner) {
  	winner = winner + 1;
  	winnerText = winnerCanvas.gameObject.transform.GetChild(0).GetComponent<Text>();
    string winnerDisplay = "PLAYER " + winner + " WINS";
    winnerText.text = winnerDisplay;
    yield return new WaitForSeconds(3f);
    SceneManager.LoadScene(0);
  }


	public static void ShuffleArray<T>(T[] arr) {
		for (int i = arr.Length - 1; i > 0; i--) {
    	int r = Random.Range(0, i);
    	T tmp = arr[i];
    	arr[i] = arr[r];
    	arr[r] = tmp;
    }
  }
}
