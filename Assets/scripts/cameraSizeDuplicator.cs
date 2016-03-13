using UnityEngine;
using System.Collections;

public class cameraSizeDuplicator : MonoBehaviour {

	public FirstPersonDrifter FirstPersonDrifter;
	public gameManager gameManager;

	void Start() {
		if (gameManager.m.numberOfPlayers == 1) {
			if (FirstPersonDrifter.playerNum == 1) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
			}
			if (FirstPersonDrifter.playerNum == 2) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
			if (FirstPersonDrifter.playerNum == 3) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
			if (FirstPersonDrifter.playerNum == 4) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
		}
		if (gameManager.m.numberOfPlayers == 2) {
			if (FirstPersonDrifter.playerNum == 1) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
			}
			if (FirstPersonDrifter.playerNum == 2) {
				GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
			if (FirstPersonDrifter.playerNum == 3) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
			if (FirstPersonDrifter.playerNum == 4) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
		}
		if (gameManager.m.numberOfPlayers == 3) {
			if (FirstPersonDrifter.playerNum == 1) {
				GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 2) {
				GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 3) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 4) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0f, 0f);
			}
		}
		if (gameManager.m.numberOfPlayers == 4) {
			if (FirstPersonDrifter.playerNum == 1) {
				GetComponent<Camera>().rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 2) {
				GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 3) {
				GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 0.5f);
			}
			if (FirstPersonDrifter.playerNum == 4) {
				GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			}
		}
	}	

}
