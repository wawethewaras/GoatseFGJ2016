using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomSwitcher : MonoBehaviour {

	public GameObject currentRoom;

	public Button upButton;
	public Button downButton;
	public Button leftButton;
	public Button rightButton;

	public void MoveUp(){
		GameObject pRoom = currentRoom.GetComponent<Room> ().roomUp;
		Camera.main.transform.position = new Vector3(pRoom.transform.position.x, pRoom.transform.position.y, Camera.main.transform.position.z);
		currentRoom = currentRoom.GetComponent<Room> ().roomUp;
	}

	public void MoveDown(){
		GameObject pRoom = currentRoom.GetComponent<Room> ().roomDown;
		Camera.main.transform.position = new Vector3(pRoom.transform.position.x, pRoom.transform.position.y, Camera.main.transform.position.z);
		currentRoom = currentRoom.GetComponent<Room> ().roomDown;
	}

	public void MoveLeft(){
		GameObject pRoom = currentRoom.GetComponent<Room> ().roomLeft;
		Camera.main.transform.position = new Vector3(pRoom.transform.position.x, pRoom.transform.position.y, Camera.main.transform.position.z);
		currentRoom = currentRoom.GetComponent<Room> ().roomLeft;
	}

	public void MoveRight(){
		GameObject pRoom = currentRoom.GetComponent<Room> ().roomRight;
		Camera.main.transform.position = new Vector3(pRoom.transform.position.x, pRoom.transform.position.y, Camera.main.transform.position.z);
		currentRoom = currentRoom.GetComponent<Room> ().roomRight;
	}

	public void ChangeRoom(GameObject room){
		currentRoom = room;
	}

}
