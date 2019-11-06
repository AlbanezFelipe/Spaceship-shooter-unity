using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	protected void move(bool moveUp = true){
		transform.Translate (new Vector2 (0, speed * (moveUp ? 1 : -1) * Time.deltaTime));
	}
}
