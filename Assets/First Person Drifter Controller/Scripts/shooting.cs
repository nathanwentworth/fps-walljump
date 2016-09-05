using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour {

	private float timer = 0.2f;
	private int points = 0;
	private int playerNumber;
	private float shotSpeed = 1;
	private float journeyLength;

	[Header("Object Refs")]
	public GameObject gunParticle;
	public GameObject sparks;
	public GameObject armTip;

  List<GameObject> gunParticleArr;

  private Transform cam;
  private Transform bod;
	
	public Text scoreText;

	public FirstPersonDrifter fpdScript;
	public GameManager gm;

	// runs on start
	void Start() {
		// gets the body object of the player, basically the outmost container
		bod = transform.parent.transform;
		// sets the gun hud number to points, which is 0 on start
		scoreText.text = points + "";
		// set the local playernumber to be whatever is in the first person drifter
		playerNumber = fpdScript.playerNum;

		// creates a pool for particle projectiles
		gunParticleArr = new List<GameObject>();
    for (int i = 0; i < 10; i++) {
    	GameObject obj = (GameObject)Instantiate(gunParticle);
      obj.SetActive(false);
      gunParticleArr.Add(obj);
    }
	}

	void Update () {
		// runs when the fire buttons is held down
		// this is using a system of "Fire + playerNumber",
		// that way each player has their own input dynamically
		if (Input.GetButton("Fire" + playerNumber)) {
			// runs the counter to zero on hold
			timer -= Time.deltaTime;
			if (timer < 0f) {
				// when that timer reaches less than zero, call the actual shoot script,
				RayDmg(10);
				// and reset that timer back to the original value of 0.2f
				timer = 0.2f;
			}
		}
	}

	// called in Update
	void RayDmg(int dmg) {
		// base ray declaration
		RaycastHit hit;
		Ray hitRay = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(hitRay, out hit)) {
			// called if the raycast hits something
			// 'hit' is the actual thing that is hit
			if (hit.transform.gameObject.tag == "Player") {
				// called if that 'hit' is the player
				if (hit.transform.gameObject.GetComponent<FirstPersonDrifter>().health <= dmg) {
					// if that 'hit' makes the target player have less than 0 health,
					// then give the shooting player a point
					points++;
					// updates the point display on the gun
					scoreText.text = points + "";
				}
				// subtract health from target player equal to damage given by shooting player
				hit.transform.gameObject.GetComponent<FirstPersonDrifter>().health -= dmg;
			}
			for (int i = 0; i < gunParticleArr.Count; i++) {
				// check particle array list
				if (!gunParticleArr[i].activeInHierarchy) {
					// when it finds one that's inactive
					// create local var for the rotation on x and y
					// x comes from the main camera
					float rotX = transform.eulerAngles.x;
					// y comes from the body
					float rotY = bod.eulerAngles.y;
					// create a variable that houses both of these
					var rotMatch = Quaternion.Euler(rotX, rotY, 0);
					// set global position of the particle as the global position of the arm tip object
					gunParticleArr[i].transform.position = armTip.transform.position;
					// set rotation to be above created variable
					gunParticleArr[i].transform.rotation = rotMatch;
					// set particle as active
					gunParticleArr[i].SetActive(true);
					// break so that it doesn't do this more than once per shot
					break;
				}
			}
		}
	}
}
