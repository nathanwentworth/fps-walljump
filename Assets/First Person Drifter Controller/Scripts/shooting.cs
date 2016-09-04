using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour {

	private float timer = 0;
	private float cooldown = 0;
	private float visibility = 0;
	private int points = 0;
	private int playerNumber;
	private float shotSpeed = 1;
	private float journeyLength;

	[Header("Object Refs")]
	public GameObject gunParticle;
	public GameObject sparks;
	public GameObject armTip;
	public GameObject cam;

  List<GameObject> gunParticleArr;

	
	public Text scoreText;

	public FirstPersonDrifter fpdScript;
	public GameManager gm;

	void Start() {
		scoreText.text = points + "";
		playerNumber = fpdScript.playerNum;

		gunParticleArr = new List<GameObject>();
    for (int i = 0; i < 10; i++) {
    	GameObject obj = (GameObject)Instantiate(gunParticle);
      obj.SetActive(false);
      gunParticleArr.Add(obj);
    }
	}

	void Update () {
		cooldown -= Time.deltaTime;
		visibility -= Time.deltaTime;

		if (cooldown <= 0) {
			if (Input.GetButton("Fire" + playerNumber)) {
				timer += Time.deltaTime;
				if (timer > 0.2f) {
					RayDmg(10);
					timer = 0;
				}
			}	
		}
	}

	void RayDmg(int dmg) {
		RaycastHit hit;
		Ray hitRay = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(hitRay, out hit)) {
			if (hit.transform.gameObject.tag == "Player") {
				if (hit.transform.gameObject.GetComponent<FirstPersonDrifter>().health <= dmg) {
					points++;
					scoreText.text = points + "";
				}
				hit.transform.gameObject.GetComponent<FirstPersonDrifter>().health -= dmg;
			}
			for (int i = 0; i < gunParticleArr.Count; i++) {
				if (!gunParticleArr[i].activeInHierarchy) {
					gunParticleArr[i].transform.position = armTip.transform.position;
					gunParticleArr[i].transform.forward = transform.parent.transform.forward;
					gunParticleArr[i].SetActive(true);
					break;
				}
			}
		}
	}
}
