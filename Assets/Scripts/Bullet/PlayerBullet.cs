using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.gameObject.CompareTag ("PlayerLimiter")) {
			Destroy (this.gameObject);
		}
		if (trigger.gameObject.CompareTag ("Enemy")) {
			Destroy (this.gameObject);
		}
	}
}
