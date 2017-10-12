using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Box : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		if(col.tag=="rfh"||col.tag=="lfh"){
			GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Start game!";
			print ("Enter");
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Hand out!";
		print ("Exit");
	}
}