using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Song_R{
	public string name;
	public AudioClip[] Chap0;
	public AudioClip[] Chap1;
	public AudioClip[] Chap2;
	public AudioClip[] Chap3;
}



public class SongManager : MonoBehaviour {
	public Song_R[] songlist;
	//public AudioClip[] Guitar_clips;
	//public AudioClip[] Piano_clips;
	//public AudioClip[] Trumpet_clips;
	//public AudioClip[] Violin_clips;
	public int SequenceLength;
	private AudioSource audioSource;
	private bool playNow = false;
	private bool recordNow = false;
	private int cnt = 0;
	private static string[] current_sequence;
	public static List<string> Rcvlist;
	public static bool start_game;
	public int Song_id;
	 



	private AudioClip RandomSelector(AudioClip[] clips){
		return clips [Random.Range (0, clips.Length)];
	}

	private int Song_Index_Random_Generator(){
		int my_s_id = Random.Range (0, songlist.Length);
		return my_s_id;
	}

	private string[] Gen_song_sequence(){
		string[] pickup_bucket = new string[] { "G", "V", "O", "P" };
		string[] return_sequence = new string[SequenceLength];
		for (int i = 0; i < pickup_bucket.Length; i++){
			string currentout = pickup_bucket [Random.Range (0, pickup_bucket.Length)];
			return_sequence [i] = currentout;
		}
		current_sequence = return_sequence;
		return return_sequence;
	}


	//fill up song list
	private AudioClip[] Fill_up_song_list(string[] song_sequence){
		string[] working_sequence = song_sequence;
		AudioClip[] return_songlist = new AudioClip[working_sequence.Length];

		for (int i = 0; i < working_sequence.Length; i++) {
			string p = working_sequence [i];
			if (p == "G") {
				if (i == 0) {
					AudioClip slcted_guitar_clip = songlist[Song_id].Chap0[2];
					return_songlist [i] = slcted_guitar_clip;
				}
				if (i == 1) {
					AudioClip slcted_guitar_clip = songlist[Song_id].Chap1[2];
					return_songlist [i] = slcted_guitar_clip;
				}
				if (i == 2) {
					AudioClip slcted_guitar_clip = songlist[Song_id].Chap2[2];
					return_songlist [i] = slcted_guitar_clip;
				}
				if (i == 3) {
					AudioClip slcted_guitar_clip = songlist[Song_id].Chap3[2];
					return_songlist [i] = slcted_guitar_clip;
				}
			} 
			else if (p == "V") {
				if (i == 0) {
					AudioClip slcted_violin_clip = songlist[Song_id].Chap0[1];
					return_songlist [i] = slcted_violin_clip;
				}
				if (i == 1) {
					AudioClip slcted_violin_clip = songlist[Song_id].Chap1[1];
					return_songlist [i] = slcted_violin_clip;
				}
				if (i == 2) {
					AudioClip slcted_violin_clip = songlist[Song_id].Chap2[1];
					return_songlist [i] = slcted_violin_clip;
				}
				if (i == 3) {
					AudioClip slcted_violin_clip = songlist[Song_id].Chap3[1];
					return_songlist [i] = slcted_violin_clip;
				}
			} 
			else if (p == "O") {
				if (i == 0) {
					AudioClip slcted_trumpet_clip = songlist[Song_id].Chap0[3];
					return_songlist [i] = slcted_trumpet_clip;
				}
				if (i == 1) {
					AudioClip slcted_trumpet_clip = songlist[Song_id].Chap1[3];
					return_songlist [i] = slcted_trumpet_clip;
				}
				if (i == 2) {
					AudioClip slcted_trumpet_clip = songlist[Song_id].Chap2[3];
					return_songlist [i] = slcted_trumpet_clip;
				}
				if (i == 3) {
					AudioClip slcted_trumpet_clip = songlist[Song_id].Chap3[3];
					return_songlist [i] = slcted_trumpet_clip;
				}
			} 
			else if (p == "P") {
				if (i == 0) {
					AudioClip slcted_piano_clip = songlist[Song_id].Chap0[0];
					return_songlist [i] = slcted_piano_clip;
				}
				if (i == 1) {
					AudioClip slcted_piano_clip = songlist[Song_id].Chap1[0];
					return_songlist [i] = slcted_piano_clip;
				}
				if (i == 2) {
					AudioClip slcted_piano_clip = songlist[Song_id].Chap2[0];
					return_songlist [i] = slcted_piano_clip;
				}
				if (i == 3) {
					AudioClip slcted_piano_clip = songlist[Song_id].Chap3[0];
					return_songlist [i] = slcted_piano_clip;
				}
			}
			//AudioClip slcted_piano_clip = RandomSelector(Piano_clips);return_songlist [i] = slcted_piano_clip;
		}
		return return_songlist;
	}

	public void fadeIn()
	{
		if (audioSource.volume < 1)
		{
			audioSource.volume += 0.1f * Time.deltaTime;
		}
	}

	public void fadeOut() 
	{
		if(audioSource.volume > 0.1)
		{
			audioSource.volume -= 0.1f * Time.deltaTime;
		}
	}


	// Gen and fill up song list return sequence to static
	private void PlaySequence (){
		AudioClip[] playlist = Fill_up_song_list (current_sequence);

		if (!audioSource.isPlaying && cnt < playlist.Length) {
			audioSource.clip = playlist [cnt];
			audioSource.Play ();
			cnt++;
		}
		if (cnt == playlist.Length) {
			cnt = 0;
			playNow = false;
			recordNow = true;
		}
		if (audioSource.volume <= 0.1) {
			fadeIn ();
		}
	}

	void Start () {
		start_game = false;
		recordNow = false;
		audioSource = FindObjectOfType<AudioSource> ();
		audioSource.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Key in space to gen song sequence
		if (Input.GetKeyDown("space")||start_game==true) {
			Song_id = Song_Index_Random_Generator (); //Generate Song Index
			current_sequence = Gen_song_sequence ();
			playNow = true;
			string songseq = string.Join ("", current_sequence);
			print ("Song Sequence: "+songseq);
			GameManager.song_sequence = songseq;
		}
		if (playNow) {
			PlaySequence ();
		}
		if (recordNow) {
			if (!audioSource.isPlaying) {
				print ("Playlist finished!");
			}
			recordNow = false;
		}
		if (start_game == true) {
			start_game = false;
		}
	}
}
