using UnityEngine;
using System.Collections;

public class cameraSizeDuplicator : MonoBehaviour {

	public FirstPersonDrifter FirstPersonDrifter;
	public GameManager gm;
	private int players;

	void Start() {
		players = gm.NumberOfPlayers;
		if (players == 1) {
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
		if (players == 2) {
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
		if (players == 3) {
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
		if (players == 4) {
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
