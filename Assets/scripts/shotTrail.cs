using UnityEngine;
using System.Collections;

public class shotTrail : MonoBehaviour {

	float shotSpeed = 3;
	float timer;

	// when this object is set active by shooting.cs, the timer is set to 0
	void OnEnable() {
		timer = 0;
	}
	// then, the projectile moves forward at the speed set by shotSpeed (units per second)
	// then once the timer is 2 seconds it sets itself inactive
	void FixedUpdate () {
		transform.position += transform.forward * shotSpeed;
		timer += Time.deltaTime;
		if (timer > 2) {
			gameObject.SetActive(false);
		}
	}
}
