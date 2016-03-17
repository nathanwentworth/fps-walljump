﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour {

	private float timer = 0;
	private float cooldown = 0;
	private float visibility = 0;
	private int points = 0;
	private int playerNumber;

	public GameObject gunParticle;
	
	public Text scoreText;

	public FirstPersonDrifter FirstPersonDrifter;
	public gameManager gameManager;

	void Start() {
		scoreText.text = points + "";
		playerNumber = FirstPersonDrifter.playerNum;
	}

	void Update () {
		cooldown -= Time.deltaTime;
		visibility -= Time.deltaTime;

		if (cooldown <= 0) {
			if (Input.GetButton("Fire" + playerNumber)) {
				timer += Time.deltaTime;
			}
			if (Input.GetButtonUp("Fire" + playerNumber) || timer >= 4) {
				RayTime(timer);
				timer = 0;
			}			
		}
	}

	void RayTime(float timer) {
		if (timer < 2) {
			RayDmg(10);
		} 
		else if (timer >= 2 && timer < 4) {
			RayDmg(20);
			cooldown = 1;
		}
		else {
			RayDmg(90);
			cooldown = 2;
		}
	}

	void RayDmg(int dmg) {
		RaycastHit hit;
		Ray hitRay = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(hitRay, out hit)) {
			if (hit.transform.gameObject.tag == "Player") {
				if (hit.transform.gameObject.GetComponent<testHealth>().health <= dmg) {
					points++;
					scoreText.text = points + "";
					gameManager.m.playerScores[playerNumber - 1] = points;
					if (points >= (gameManager.m.numberOfPlayers - 1)) {
						SceneManager.LoadScene(0);
					}
				}
				hit.transform.gameObject.GetComponent<testHealth>().health -= dmg;
			}
		}		
		gunParticle.GetComponent<ParticleSystem>().Emit(1);
	}
}
