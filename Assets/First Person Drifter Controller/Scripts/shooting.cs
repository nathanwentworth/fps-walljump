using UnityEngine;
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
	public GameObject sparks;
	
	public Text scoreText;

	public FirstPersonDrifter fpdScript;
	public gameManager gameManager;

	void Start() {
		scoreText.text = points + "";
		playerNumber = fpdScript.playerNum;
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
					foreach (int i in gameManager.m.PlayerScores) {
						if (i >= gameManager.m.NumberOfPlayers) {
							// to change later
							SceneManager.LoadScene(0);
						}
					}
					gameManager.m.PlayerScores[playerNumber - 1] = points;
					if (points >= (gameManager.m.NumberOfPlayers - 1)) {
						SceneManager.LoadScene(0);
					}
				}
				hit.transform.gameObject.GetComponent<testHealth>().health -= dmg;
			}
			Instantiate(sparks, hit.point, Quaternion.identity);
		}		
		gunParticle.GetComponent<ParticleSystem>().Emit(1);
	}
}
