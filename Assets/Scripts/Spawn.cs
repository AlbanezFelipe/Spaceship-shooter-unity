using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	private int counter;
	private float size;
	public int frequency;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		counter = 0;
		size = this.GetComponent<BoxCollider2D> ().size.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter >= frequency) {
			Instantiate (enemy, new Vector3 (Random.Range (-size, size), this.transform.position.y, this.transform.position.z), Quaternion.identity);
			counter = 0;
		}
	}
}
