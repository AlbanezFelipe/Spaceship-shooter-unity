using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spaceship {

	public int fireFrequency;
	private int fireCounter;
	private bool fireReloading;
	private ControllerManager controller;

	// Use this for initialization
	void Start () {
		spaceshipCreated (
			new SpaceshipAnimation(GetComponent<Animator>(), "BlueExplosion")
		);
		fireCounter = 0;
		fireReloading = false;
	}

	// Update is called once per frame
	void Update () {
		if (!destroyed) {
			playerMove ();
			playerFire ();
		}
	}

	private void playerMove(){
		move(ControllerManager.vertical(), ControllerManager.horizontal());
	}

	private void playerFire(){

		if (ControllerManager.fire() && !fireReloading) {
			fire ();
			fireReloading = true;
			fireCounter = 0;
		}

		if (fireReloading){
			fireCounter++;
		}

		if(fireCounter >= fireFrequency){
			fireReloading = false;
		}

	}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.CompareTag ("EnemyFire")) {
			explode ();
			//print ("player was hit by shot");
		}
		if (obj.gameObject.CompareTag ("Enemy")) {
			explode ();
			//print ("player was hit on enemy");
		}
	}
}
