using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScalePuzzle : MonoBehaviour {

	public int weightedTowards = 0;
	public GameObject rightSide;
	public GameObject leftSide;


    public GameObject openDoorTo;
    public GameObject openDoorFrom;
    public GameObject door;
    Vector3 doorLocation;
    public RoomSwitcher theRoomSwitcher;


    private float check = 0.5f;
    private float checkCounter;

    void Start() {
        doorLocation = door.transform.position;
    }
    public void CheckSides(){
        //int rightWeight = rightSide.countWeight();

        weightedTowards = rightSide.GetComponent<ScaleSide>().countWeight() - leftSide.GetComponent<ScaleSide>().countWeight();
        //print(weightedTowards);
        //rightSide.GetComponent<ScaleSide>().resetWeight();
        //leftSide.GetComponent<ScaleSide>().resetWeight();

		UpdateAnim ();

    }

	void Update (){

        CheckSides();
        if (weightedTowards == 30)
        {
            OpenDoor();
        }
        else {
            CloseDoor();
        }
	}
    void OpenDoor()
    {
        openDoorFrom.GetComponent<Room>().roomUp = openDoorTo;
        theRoomSwitcher.CheckButtons();
        door.transform.position = new Vector3(doorLocation.x - 10f, doorLocation.y, doorLocation.z);
    }
    void CloseDoor()
    {
        openDoorFrom.GetComponent<Room>().roomUp = null;
        door.transform.position = new Vector3(doorLocation.x, doorLocation.y, doorLocation.z);
        theRoomSwitcher.CheckButtons();
    }

	void UpdateAnim(){

		GetComponent<Animator> ().SetInteger ("direction", weightedTowards);

	}
}
