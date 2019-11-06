using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move (moveUp : false);
	}
	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.gameObject.CompareTag ("EnemyLimiter")) {
			Destroy (this.gameObject);
		}
		if (trigger.gameObject.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}
}
