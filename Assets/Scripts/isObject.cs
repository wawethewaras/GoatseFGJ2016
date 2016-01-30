using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    public string itemThatActivates;
	public GameObject affectedObject;
    public string itemInfo;
    public bool activatesInfo;

    public GameObject currentRoom;
    public GameObject openRoom;
    RoomSwitcher theRoomSwitcher;

    void Start() {
        theRoomSwitcher = FindObjectOfType<RoomSwitcher>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState.Equals("Empty") && activatesInfo)
        {
            ItemCursor.current.EnableInfo(itemInfo);
        }
            if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState == itemThatActivates)
        {
            ItemCursor.current.RemoveItem();

			if (gameObject.name == "skull") {
				DropKey ();
			}
            if (gameObject.name == "EvilSanta")
            {
                OpenDoor();
            }
        }
    }

    void DropKey()
    {
        if (affectedObject != null) {
            affectedObject.SetActive(true);
            affectedObject.GetComponent<BoxCollider2D>().enabled = true;
        }
	}

    void OpenDoor() {
        
        currentRoom.GetComponent<Room>().roomUp = openRoom;
        theRoomSwitcher.CheckButtons();
    }

    void OnMouseEnter()
    {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
            ItemCursor.current.ChangeCursor();
        }
    }
    void OnMouseExit()
    {
        ItemCursor.current.ReturnCursor();
    }
}
