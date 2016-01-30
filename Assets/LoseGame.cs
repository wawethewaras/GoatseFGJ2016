using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {

	public Text loseText;
	public GameObject loseGameScreen;
	private bool gameLost = false;
	private float loseGameTime;

	void Start (){
		//set timescale to 1 IMPORTANT FOR RESTARTING GAME
		Time.timeScale = 1;
		loseGameTime = 0;
	}

	public void LoseTheGame(){
		//enable end screen
		loseGameScreen.SetActive (true);
		gameLost = true;
		//pause game in bg
		Time.timeScale = 0;
		loseText.text = "You're the worst satanist ever. Jesus still loves you.";
	}

	void Update (){
		//if game is lost, enable going to credits
		if (gameLost) {
			loseGameTime += Time.deltaTime;
			if (loseGameTime > 0f && Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1;
				SceneManager.LoadScene ("credits");
			}
		}
	}

}

