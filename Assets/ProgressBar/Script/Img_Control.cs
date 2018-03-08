using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Img_Control : MonoBehaviour {
	public AnimationCurve ac;
	int ac_int = -1;
	Vector3[] s;
	Image[] images;
	Image[] symbols;
	float playSpeed = 2;
	public Sprite[] sprite_list;
	public Sprite[] check_symbols_list;
	int instrument_amount = 4;
	GameObject instrc_txt;
	Dictionary<string, int> gesture_dict;
	public static bool[] oneshot_flag;
	string[] checkarray;
	int score;
	public int section_score = 25;
	GameObject Check_symbol_panel;

	// Use this for initialization
	void Start () {
		// For now ini score as 0 since no dbs, bf or hf
		score = 0;
		//
		Check_symbol_panel = GameObject.Find("Check_Symbol_Panel");
		string[] checkarray = new string[4];
		oneshot_flag = new bool[] {true, true, true, true};
		gesture_dict = new Dictionary<string, int>();
		instrc_txt = GameObject.FindGameObjectWithTag("instruction_text");
		s = new Vector3[instrument_amount];
		int tcnt = transform.childCount;
		for (int i=0;i<tcnt;i++){
			s [i] = transform.GetChild (i).localScale;
		}
		images = transform.GetComponentsInChildren<Image> ();
		symbols = Check_symbol_panel.GetComponentsInChildren<Image> ();
	}

	int[] evalute_input(string[] playlist){
		int[] output = new int[4];
		for (int i = 0; i < output.Length; i++) {
			if (playlist [i] == "P") {
				output [i] = 0;
			}
			else if (playlist [i] == "O") {
				output [i] = 1;
			}
			else if (playlist [i] == "V") {
				output [i] = 2;
			}
			else if (playlist [i] == "G") {
				output [i] = 3;
			}
		}
		return output;
	}

	void play_one_shot_animation(int i){
		float r = ac.Evaluate (Time.time * playSpeed);
		transform.GetChild (i).transform.localScale = new Vector3 (s[i].x * r, s[i].y * r, s[i].z);
	}

	void appending_gesture_signals (Dictionary<string, int> dict, string gesture_msg){
		if (!dict.ContainsKey (gesture_msg)) {
			dict.Add (gesture_msg, 1);
		}
		if (dict.ContainsKey (gesture_msg)) {
			dict [gesture_msg] = dict [gesture_msg] + 1;
		}
	}

	string validate_gesture_dict(Dictionary<string, int> dict){
		string output = "";
		int value = 0;
		foreach (string key in dict.Keys){
			if ((dict [key] > value) && key!="Error") {
				value = dict [key];
				output = key;
			}
		}
		gesture_dict = new Dictionary<string, int>();
		return output;
	}

	string[] reformat_sequence(string[] in_sequence){
		string[] output = new string[4];
		for (int i = 0; i < output.Length; i++) {
			if (in_sequence[i] == "V") {
				output[i] = "Violin";
			}
			if (in_sequence[i] == "O") {
				output[i] = "Trumpet";
			}
			if (in_sequence[i] == "G") {
				output[i] = "Guitar";
			}
			if (in_sequence[i] == "P") {
				output[i] = "Piano";
			}
		}
		return output;
	}

	void udt_imgs_text(){
		string in_signal = ProgressBar.ProgressBarBehaviour.progress_bar_signal;
		string[] playlist = SongManager.current_sequence;
		string gesture_input = Gesture_tst.gesture_Msg;
		if (playlist == null) {
			instrc_txt.GetComponent<Text>().text = "Please Wait for the input!";
		}
		if (playlist != null) {
			instrc_txt.GetComponent<Text>().text = "Kindly listen to the music!";
			int[] rf_img_index_list = evalute_input (playlist);

			//Bar 1
			if (in_signal == "Progressing Bar 1") {
				instrc_txt.GetComponent<Text>().text = "What was the first instrument in the series?";
				appending_gesture_signals (gesture_dict, gesture_input);
			}
			if ((in_signal == "Bar 1 Completed" || in_signal == "Progressing Bar 2") && oneshot_flag[0]) {
				images [0].sprite = sprite_list [rf_img_index_list [0]];
				ac_int = 0;
				oneshot_flag [0] = false;
				string output0 = validate_gesture_dict (gesture_dict);
				print ("s1 net out: " + output0);
				checkarray = reformat_sequence (SongManager.current_sequence);
				if (output0 == checkarray [0]) {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Correct!";
					score += section_score;
					string score_out = "Score: " + score.ToString();
					GameObject.FindGameObjectWithTag ("score_tag").GetComponent<Text> ().text = score_out;
					symbols [0].sprite = check_symbols_list [0];
				} else {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Wrong!";
					symbols [0].sprite = check_symbols_list [1];
				}
			}

			//Bar 2
			if (in_signal == "Progressing Bar 2") {
				instrc_txt.GetComponent<Text>().text = "What was the second instrument in the series?";
				appending_gesture_signals (gesture_dict, gesture_input);
			}
			if ((in_signal == "Bar 2 Completed" || in_signal == "Progressing Bar 3") && oneshot_flag[1]) {
				images [1].sprite = sprite_list [rf_img_index_list [1]];
				ac_int = 1;
				oneshot_flag [1] = false;
				string output1 = validate_gesture_dict (gesture_dict);
				print ("s2 net out: " + output1);
				if (output1 == checkarray [1]) {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Correct!";
					score += section_score;
					string score_out = "Score: " + score.ToString();
					GameObject.FindGameObjectWithTag ("score_tag").GetComponent<Text> ().text = score_out;
					symbols [1].sprite = check_symbols_list [0];
				} else {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Wrong!";
					symbols [1].sprite = check_symbols_list [1];

				}
			}

			//Bar 3
			if (in_signal == "Progressing Bar 3") {
				instrc_txt.GetComponent<Text>().text = "What was the third instrument in the series?";
				appending_gesture_signals (gesture_dict, gesture_input);
			}
			if ((in_signal == "Bar 3 Completed" || in_signal == "Progressing Bar 4") && oneshot_flag[2]) {
				images [2].sprite = sprite_list [rf_img_index_list [2]];
				ac_int = 2;
				oneshot_flag [2] = false;
				string output2 = validate_gesture_dict (gesture_dict);
				print ("s3 net out: " + output2);
				if (output2 == checkarray [2]) {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Correct!";
					score += section_score;
					string score_out = "Score: " + score.ToString();
					GameObject.FindGameObjectWithTag ("score_tag").GetComponent<Text> ().text = score_out;
					symbols [2].sprite = check_symbols_list [0];
				} else {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Wrong!";
					symbols [2].sprite = check_symbols_list [1];

				}
			} 

			//Bar 4
			if (in_signal == "Progressing Bar 4") {
				instrc_txt.GetComponent<Text>().text = "What was the last instrument in the series?";
				appending_gesture_signals (gesture_dict, gesture_input);
			}
			if ((in_signal == "Bar 2 Completed" || in_signal == "Game Finished") && oneshot_flag[3]) {
				images [3].sprite = sprite_list [rf_img_index_list [3]];
				ac_int = 3;
				oneshot_flag [3] = false;
				string output3 = validate_gesture_dict (gesture_dict);
				print ("s4 net out: " + output3);
				if (output3 == checkarray [3]) {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Correct!";
					score += section_score;
					string score_out = "Score: " + score.ToString();
					GameObject.FindGameObjectWithTag ("score_tag").GetComponent<Text> ().text = score_out;
					symbols [3].sprite = check_symbols_list [0];
				} else {
					GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text> ().text = "Wrong!";
					symbols [3].sprite = check_symbols_list [1];
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		udt_imgs_text ();
	}
}
