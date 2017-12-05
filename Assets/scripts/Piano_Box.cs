using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Piano_Box : MonoBehaviour {
	public static bool start_checking;

	void Start(){
		start_checking = false;
	}

	void Update(){
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag=="lfh" && start_checking==true){
			print ("Enter Piano Box");
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "lfh" && start_checking == true) {
			print ("Exit Piano Box, Piano Registered");
			GameManager.user_input_sequence = GameManager.user_input_sequence + "P";
		}
	}
}
