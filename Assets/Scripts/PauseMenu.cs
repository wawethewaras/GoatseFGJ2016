using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Slider volumeSlider;
	public Slider effectsSlider;

	public AudioSource effectsSource;
	public AudioSource musicSource;

	public GameObject pauseMenu;

	void Update(){
		//if esc is pressed
		if(Input.GetKeyDown(KeyCode.Escape)){
			//if game is going
			if (Time.timeScale == 1) {
				Pause ();
			} else {
				UnPause ();
			}
		}
		if(effectsSource != null)
			effectsSource.volume = effectsSlider.value;

		if(musicSource != null)
			musicSource.volume = volumeSlider.value;


	}

	void Pause(){
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
	}

	public void UnPause(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}

	public void BackToMenu(){
		UnPause ();
		SceneManager.LoadScene ("mainmenu");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
