using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flag_tst : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		print ("Enter");
	}

	void OnTriggerStay(Collider col) {
		print ("Stay");
	}

	void OnTriggerExit(Collider col) {
		print ("Exit");
	}
}