using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	public GameObject roomUp;
	public GameObject roomDown;
	public GameObject roomLeft;
	public GameObject roomRight;

	public AudioClip[] roomEffects;
	public AudioClip roomMusic;

	public void OnRoomEnter(){
		print ("lol");
		if (roomEffects.Length != 0) {
			for (int i = 0; i < roomEffects.Length; i++) {
				AudioPlayer.current.PlaySoundClip (roomEffects [i].name);
			}
		}
			
		if (roomMusic != null) {
			AudioPlayer.current.PlayMusicClip (roomMusic.name, true);
		} else {
			AudioPlayer.current.StartCoroutine ("PlayMusic");
		}
	}
}
