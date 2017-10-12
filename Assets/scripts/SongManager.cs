using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {
	public AudioClip[] Guitar_clips;
	public AudioClip[] Piano_clips;
	public AudioClip[] Orchestra_clips;
	public AudioClip[] Violin_clips;
	public int SequenceLength;
	private AudioSource audioSource;
	private bool playNow = false;
	private bool recordNow = false;
	private int cnt = 0;
	private static string[] current_sequence;
	public static List<string> Rcvlist;


	private AudioClip RandomSelector(AudioClip[] clips){
		return clips [Random.Range (0, clips.Length)];
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
				AudioClip slcted_guitar_clip = RandomSelector (Guitar_clips);
				return_songlist [i] = slcted_guitar_clip;
			} 
			else if (p == "V") {
				AudioClip slcted_violin_clip = RandomSelector(Violin_clips);
				return_songlist [i] = slcted_violin_clip;
			} 
			else if (p == "O") {
				AudioClip slcted_orchestra_clip = RandomSelector(Orchestra_clips);
				return_songlist [i] = slcted_orchestra_clip;
			} 
			else if (p == "P") {
				AudioClip slcted_piano_clip = RandomSelector(Piano_clips);
				return_songlist [i] = slcted_piano_clip;
			}
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
		recordNow = false;
		audioSource = FindObjectOfType<AudioSource> ();
		audioSource.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Key in space to gen song sequence
		if (Input.GetKeyDown ("space")) {
			current_sequence = Gen_song_sequence ();
			playNow = true;
			string songseq = string.Join ("", current_sequence);
			print ("Song Sequence: "+songseq);
		}
		if (playNow) {
			PlaySequence ();
		}
		if (recordNow) {
		}
	}
}
