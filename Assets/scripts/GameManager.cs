using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static bool start_game;
	public static string song_sequence = "";
	public static string user_input_sequence = "";
	// Use this for initialization
	void Start () {
		start_game = false;
	}
	
	// Update is called once per frame

	void Update () {
		start_game_signaling ();
		Check_Userinput ();


	}

	//Start game signaling
	private void start_game_signaling(){
		if (start_game == true) {
			//Turn on the music player
			SongManager.start_game = true;

			//Turn on the checking label
			Piano_Box.start_checking = true;
			Violin_Box.start_checking = true;
			Orch_Box.start_checking = true;
			Guitar_Box.start_checking = true;

			//Fasle the start game offset
			start_game = false;
		}
	}

	//Check Userinput matching or not
	private void Check_Userinput(){
		if (user_input_sequence.Length == song_sequence.Length && song_sequence.Length != 0) {
			print ("Checking");
			print ("Expected: " + song_sequence);
			print ("User input: " + user_input_sequence);
			if (song_sequence == user_input_sequence) {
				print ("Correct!");
				GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Correct!";
			} else {
				print ("Not Correct!");
				GameObject.FindGameObjectWithTag ("test_tag").GetComponent<Text> ().text = "Failed!";
			}
		}
	}
}
