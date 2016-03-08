using UnityEngine;
using System.Collections;

public class testHealth : MonoBehaviour {

	[HideInInspector]
	public int health = 100;
	
	void Update () {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
