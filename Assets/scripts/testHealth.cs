using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHealth : MonoBehaviour {

	// [HideInInspector]
	public int health = 100;
	public Image healthCircle;
	public gameManager gameManager;

	public GameObject model;
	public GameObject arm;
	public GameObject cam;
	
	void Update () {

		healthCircle.fillAmount = (health * .01f);

		if (health <= 0) {
			GetComponent<CharacterController>().enabled = false;
			model.SetActive(false);
			arm.SetActive(false);
			cam.GetComponent<shooting>().enabled = false;
		}
	}
}
