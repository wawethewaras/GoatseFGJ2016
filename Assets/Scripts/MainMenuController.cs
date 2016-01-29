using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    public GameObject StartButton;
    public GameObject QuitButton;
    public string startLevel;

    public void StartGame() {
        Debug.Log("StartGame");
        //Application.LoadLevel(startLevel);
    }
    public void QuitGame() {
        Debug.Log("Quit");
        //Application.Quit();
    }
}
