using UnityEngine;
using System.Collections;

public class LeverManager : MonoBehaviour {

    public isLever[] levers;
    public GameObject openDoorFrom;
    public GameObject openDoorTo;
    public RoomSwitcher theRoomSwitcher;
    public GameObject BookShell;
    Vector3 bookShelfLocation;

    void Start() {
        bookShelfLocation = new Vector3(BookShell.transform.position.x, BookShell.transform.position.y, BookShell.transform.position.z);

    }
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
        BookShell.transform.position = new Vector3(bookShelfLocation.x - 10f, bookShelfLocation.y, bookShelfLocation.z);
    }
    void CloseDoor() {
        openDoorFrom.GetComponent<Room>().roomUp = null;
        BookShell.transform.position = new Vector3(bookShelfLocation.x, bookShelfLocation.y, bookShelfLocation.z);
    }
}
