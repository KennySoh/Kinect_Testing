using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink_Animation : MonoBehaviour {
	public AnimationCurve ac;
	Vector3[] s;
	float playSpeed = 2;
	float timeOffset = 0;
	bool flag = false;
	int instrument_amount = 4;
	// Use this for initialization
	void Start () {
		s = new Vector3[instrument_amount];
		int tcnt = transform.childCount;
		for (int i=0;i<tcnt;i++){
			s [i] = transform.GetChild (i).localScale;
		}
		timeOffset = Random.value;
	}

	void Play_Shrink_Signal(){
		string instrument = SongManager.current_instrument;
		float r = ac.Evaluate (Time.time * playSpeed);
		if (instrument == "V"){
			transform.GetChild(0).transform.localScale = new Vector3 (s[0].x * r, s[0].y * r, s[0].z);
		}
		else if (instrument == "O"){
			transform.GetChild(1).transform.localScale = new Vector3 (s[1].x * r, s[1].y * r, s[1].z);
		}
		else if (instrument == "P"){
			transform.GetChild(2).transform.localScale = new Vector3 (s[2].x * r, s[2].y * r, s[2].z);
		}
		else if (instrument == "G"){
			transform.GetChild(3).transform.localScale = new Vector3 (s[3].x * r, s[3].y * r, s[3].z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Play_Shrink_Signal ();
	}
}
