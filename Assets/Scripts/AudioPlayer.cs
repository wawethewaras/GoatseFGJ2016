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
	public void PlaySoundClip(string clipName, bool loop = false){

		if(loop == true)
			source.loop = true;

		if ((Time.time - lastPlayed) > 0.0f){
			if (clipName == "doorOpen") {
				source.PlayOneShot (audioClips [0]);
			} else if (clipName == "doorLocked") {
				source.PlayOneShot (audioClips [1]);
			} else if (clipName == "dropItem") {
				source.PlayOneShot (audioClips [2]);
			} else if (clipName == "raven") {
				source.PlayOneShot (audioClips [3]);
			} else if (clipName == "pickUpItem") {
				source.PlayOneShot (audioClips [4]);
			} else if (clipName == "applause") {
				source.PlayOneShot (audioClips [5]);
			}

			lastPlayed = Time.time;
		}
	}

	public void PlayMusicClip(string clipName, bool loop = false){
		AudioPlayer.current.musicSource.Stop ();
		if (loop == true)
			musicSource.loop = true;

		if ((Time.time - lastPlayed) > 0.0f) {
			if (clipName == "AmbientForest") {
				source.PlayOneShot (musicClips [7]);
			}
		}
	}

	public IEnumerator PlayMusic(){
		//loop forever
		for (;;) {

			//get random song number
			int newSong = (int)Random.Range (0, musicClips.Length-1);
			//if it's the same as previous song
			while (newSong == previousSong) {
				//get new one
				newSong = Random.Range (0, musicClips.Length-1);
			}

			previousSong = newSong;
			//play song
			musicSource.PlayOneShot(musicClips[newSong]);
			//wait for length of song
			yield return new WaitForSeconds(musicClips[newSong].length);
		}

	}

}

