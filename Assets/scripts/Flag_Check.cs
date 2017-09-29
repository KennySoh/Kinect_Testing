using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flag_Check : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Hand in!";
		print ("Enter");
	}

	void OnTriggerExit(Collider col) {
		GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Hand out!";
		print ("Exit");
	}
}