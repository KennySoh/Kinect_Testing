using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Violin_Box : MonoBehaviour {
	private Stopwatch timer;

	void Start(){
		timer = new Stopwatch ();
	}

	void Update(){
		//if(timer.)
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag=="rfh"){
			timer.Start ();
			print ("Enter Violin");
		}
	}

	void OnTriggerExit(Collider col) {
		if(col.tag=="rfh"){
			timer.Stop ();
			print ("Exit Violin");
		}
	}
}
