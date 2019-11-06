using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float speed;
	public Renderer quad;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		quad.material.mainTextureOffset += new Vector2 (0, speed * Time.deltaTime);
	}
}
