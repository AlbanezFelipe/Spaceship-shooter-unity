using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject player;
	private GameObject _player;


	// Use this for initialization
	void Start () {
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLive() && ControllerManager.respawn())
			spawn ();
	}

	private void spawn(){
		_player = Instantiate (player, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
	}

	private bool isLive(){
		return _player != null;
	}
}
