using UnityEngine;
using System.Collections;

public class shotTrail : MonoBehaviour {

	float shotSpeed = 3;
	float timer;
	

	void OnEnable() {
		timer = 0;
	}
	void FixedUpdate () {
		transform.position += transform.forward * shotSpeed;
		timer += Time.deltaTime;
		if (timer > 2) {
			gameObject.SetActive(false);
		}
	}
}
