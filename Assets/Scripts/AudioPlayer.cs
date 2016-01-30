using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	//sfx
	public AudioClip[] audioClips;
	//songs
	public AudioClip[] musicClips;

	public AudioSource source;
	public AudioSource musicSource;

	public static AudioPlayer current;
	private float lastPlayed = 0f;
	private int previousSong;

	void Awake(){
		current = this;
	}

	void Start(){
		StartCoroutine("PlayMusic");
	}


	//play sound effect once
	public void PlaySoundClip(string clipName){
		//if an effect hasn't been played in the last 0.2 seconds
		if ((Time.time - lastPlayed) > 0.2f){
			if (clipName == "doorOpen" && (Time.time - lastPlayed) > 0.2f) {
				source.PlayOneShot (audioClips [0]);
			} else if (clipName == "doorLocked") {
				source.PlayOneShot (audioClips [2]);
			} else if (clipName == "raven") {
				source.PlayOneShot (audioClips [3]);
			} else if (clipName == "dropItem") {
				source.PlayOneShot (audioClips [4]);
			}
			lastPlayed = Time.time;
		}
	}

	public void PlayLooping(string clipName){
		if(clipName == "shaverStatic"){
			source.Stop ();
			source.PlayOneShot (audioClips [1]);
		}
	}

	IEnumerator PlayMusic(){
		//loop forever
		for (;;) {

			//get random song number
			int newSong = (int)Random.Range (0, musicClips.Length);
			//if it's the same as previous song
			while (newSong == previousSong) {
				//get new one
				newSong = Random.Range (0, musicClips.Length);
			}

			previousSong = newSong;
			//play song
			musicSource.PlayOneShot(musicClips[newSong]);
			//wait for length of song
			yield return new WaitForSeconds(musicClips[newSong].length);
		}

	}

}

