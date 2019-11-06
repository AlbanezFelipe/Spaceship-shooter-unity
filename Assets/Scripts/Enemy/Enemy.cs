using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship {

	private int counter;
	private bool movee; //true : right, false: left;

	// Use this for initialization
	void Start () {
		spaceshipCreated (new SpaceshipAnimation(GetComponent<Animator>(), "RedExplosion"));
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (!destroyed) {
			if (counter == 0) {
				movee = Random.Range (0, 2) == 1 ? true : false;
			}

			//transform.Translate(new Vector2( (move ? 1: -1 ) * speed * Time.deltaTime, 0));

			counter++;
			move (-2, (movee ? 1 : -1), new bool[]{ false, true, false, true });

			if (counter == 30) {
				fire ();
				counter = 0;
			}
		}

		//Vertical
		//transform.Translate(new Vector2( 0, -2 * Time.deltaTime));

	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.gameObject.CompareTag ("EnemyLimiter")) {
			Destroy (this.gameObject);
		}
		//if (trigger.gameObject.CompareTag ("Player")) {
		//	Destroy (this.gameObject);
			//Destroy (trigger.gameObject);
		//}
		if (trigger.gameObject.CompareTag ("PlayerFire")) {
			explode ();
			//Destroy (this.gameObject);
			//print ("enemy was hit by shot");
		}
		if (trigger.gameObject.CompareTag ("Player")) {
			explode ();
			//Destroy (this.gameObject);
			//print ("enemy was hit on player");
		}
	}


	//void OnTriggerEnter2D(Collider2D obj){
		
	//}
}
