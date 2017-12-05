using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Box : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		if(col.tag=="rfh"||col.tag=="lfh"){
			print ("Start Game!");
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Game Start!";
		GameManager.start_game = true;
		print ("Exit");
	}
}