using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testHealth : MonoBehaviour {

	// [HideInInspector]
	public int health = 100;
	public Image healthCircle;
	public gameManager gameManager;
	
	void Update () {

		healthCircle.fillAmount = (health * .01f);

		if (gameManager.m.local) {
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
		else {

		}
	}
}
