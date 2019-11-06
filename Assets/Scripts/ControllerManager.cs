using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

	public static bool fire(){
		return Input.GetAxis ("Fire1") != 0;
	}

	public static float horizontal(){
		return Input.GetAxis ("Horizontal");
	}

	public static float vertical(){
		return Input.GetAxis ("Vertical");
	}

	public static bool respawn(){
		return Input.GetAxis ("Submit") != 0;
	}
}
