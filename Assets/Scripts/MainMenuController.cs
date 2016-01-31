using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    public GameObject StartButton;
    public GameObject QuitButton;
    public string startLevel;

    public void StartGame() {
        
        Application.LoadLevel("test");
    }
    public void QuitGame() {
      
        Application.Quit();
    }
}
