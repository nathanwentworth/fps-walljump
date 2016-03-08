using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	private int i = 0;
	private float timer = 0;
	private float cooldown = 0;

	public GameObject explosion;
	public GameObject testPlayer;

	void Update () {
		cooldown -= Time.deltaTime;

		if (cooldown <= 0) {
			if (Input.GetButton("Fire1")) {
				timer += Time.deltaTime;
			}
			if (Input.GetButtonUp("Fire1") || timer >= 4) {
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
			Debug.DrawRay(hitRay.origin, hitRay.direction, Color.green, 2);
			i++;
			if (hit.transform.gameObject.tag == "Player") {
				hit.transform.gameObject.GetComponent<testHealth>().health -= dmg;
			}
			// Instantiate(explosion, hit.transform.position, Quaternion.identity);
		}
	}
}
