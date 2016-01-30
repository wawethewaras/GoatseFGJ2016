using UnityEngine;
using System.Collections;

public class LeverManager : MonoBehaviour {

    public isLever[] levers;
    public GameObject openDoorFrom;
    public GameObject openDoorTo;
    public RoomSwitcher theRoomSwitcher;

	
	// Update is called once per frame
	void Update () {
        if (levers[0].activated && !levers[1].activated && !levers[2].activated)
        {
            OpenDoor();
        }
        else {
            CloseDoor();
        }
	}

    void OpenDoor() {
        openDoorFrom.GetComponent<Room>().roomUp = openDoorTo;
        theRoomSwitcher.CheckButtons();
    }
    void CloseDoor() {
        openDoorFrom.GetComponent<Room>().roomUp = null;
    }
}
