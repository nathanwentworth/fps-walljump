using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour {

	private int i = 0;
	private float timer = 0;
	private float cooldown = 0;
	private float visibility = 0;
	private int points = 0;

	public GameObject explosion;
	public GameObject testPlayer;
	public GameObject armTip;
	public GameObject gunParticle;
	
	public Text scoreText;

	public FirstPersonDrifter FirstPersonDrifter;
	public gameManager gameManager;

	// private LineRenderer lineRenderer;

	void Start() {
		// lineRenderer = GetComponent<LineRenderer>();
		// lineRenderer.enabled = false;
		scoreText.text = points + "";
		Debug.Log(gameManager.numberOfPlayers);

	}

	void Update () {
		cooldown -= Time.deltaTime;
		visibility -= Time.deltaTime;
		// lineRenderer.material.SetColor("_TintColor", Color(.5,.5,.5,visibility));

		// lineRenderer.SetPosition(0, armTip.transform.position);

		if (cooldown <= 0) {
			if (Input.GetButton("Fire" + FirstPersonDrifter.playerNum)) {
				timer += Time.deltaTime;
			}
			if (Input.GetButtonUp("Fire" + FirstPersonDrifter.playerNum) || timer >= 4) {
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
			Debug.Log(dmg);
			// lineRenderer.enabled = true;
			// lineRenderer.SetPosition(1, hit.point);
			i++;
			if (hit.transform.gameObject.tag == "Player") {
				if (hit.transform.gameObject.GetComponent<testHealth>().health <= dmg) {
					points++;
					scoreText.text = points + "";
				}
				hit.transform.gameObject.GetComponent<testHealth>().health -= dmg;
			}
		}
		if (points >= gameManager.numberOfPlayers) {
			SceneManager.LoadScene(0);
		}
		gunParticle.GetComponent<ParticleSystem>().Emit(1);
	}
}
