using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomSwitcher : MonoBehaviour {

	public GameObject currentRoom;

	public Button upButton;
	public Button downButton;
	public Button leftButton;
	public Button rightButton;

    void Start() {
        CheckButtons();
        Camera.main.transform.position = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, Camera.main.transform.position.z);
    }

	public void ChangeRoom(string room){
		GameObject pRoom = null;

		if (room == "left") {
			pRoom = currentRoom.GetComponent<Room> ().roomLeft;
		} else if (room == "right") {
			pRoom = currentRoom.GetComponent<Room> ().roomRight;
		} else if (room == "up") {
			pRoom = currentRoom.GetComponent<Room> ().roomUp;
		} else if (room == "down") {
			pRoom = currentRoom.GetComponent<Room> ().roomDown;
		}

		Camera.main.transform.position = new Vector3 (pRoom.transform.position.x, pRoom.transform.position.y, Camera.main.transform.position.z);
		currentRoom = pRoom;

		AudioPlayer.current.source.Stop ();
		pRoom.GetComponent<Room> ().OnRoomEnter ();

		AudioPlayer.current.PlaySoundClip ("doorOpen");
		CheckButtons ();
		
	}

	public void CheckButtons(){
		if (currentRoom.GetComponent<Room> ().roomDown == null) {
			downButton.gameObject.SetActive(false);
		} else {
			downButton.gameObject.SetActive(true);
		}

		if (currentRoom.GetComponent<Room> ().roomUp == null) {
			upButton.gameObject.SetActive(false);
		} else {
			upButton.gameObject.SetActive(true);
		}

		if (currentRoom.GetComponent<Room> ().roomRight == null) {
			rightButton.gameObject.SetActive(false);
		} else {
			rightButton.gameObject.SetActive(true);
		}

		if (currentRoom.GetComponent<Room> ().roomLeft == null) {
			leftButton.gameObject.SetActive(false);
		} else {
			leftButton.gameObject.SetActive(true);
		}
	}

}
