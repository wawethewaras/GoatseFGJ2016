using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	void Update(){
		if(Input.GetMouseButtonUp(0)){
			ItemCursor.current.ReturnCursor();
			ItemCursor.current.cursorOnObject = false;
		}
	}
    void OnMouseOver()
    {
		

        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState.Equals("Empty") && activatesInfo)
        {
			ItemCursor.current.StartCoroutine("EnableInfo", itemInfo);
        }


        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState == itemThatActivates)
    	{
            

			if (gameObject.name == "Skull") {
				DropKey ();
			}
            if (gameObject.name == "EvilSanta")
            {
                ItemCursor.current.RemoveItem();
                OpenDoor();
            }
            if (gameObject.tag == "Goat")
            {
                KillGoat();
            }
            if (gameObject.tag == "Candle") {
				CandleLightingGame.current.LightCandle (gameObject);
			}

			if (gameObject.name == "Rope") {
				CutRope ();
			}
            /*
			if (gameObject.name == "SacrificeCircle") {
				SacrificePuzzle.goatPlaced = true;
				print ("goatplaced");
			}*/
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
        transform.position = new Vector3(transform.position.x +3.9f, transform.position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 180f, 0);
    }
    void KillGoat() {
        Debug.Log("Game over");
    }

	void CutRope(){
		affectedObject.GetComponent<ItemInGround> ().canPickUp = true;
		Destroy (gameObject);
	}

    void OnMouseEnter()
    {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
			ItemCursor.current.ObjectCursor ();
			ItemCursor.current.cursorOnObject = true;
        }
    }
    void OnMouseExit()
    {
		if (!Input.GetMouseButton (0)) {
			ItemCursor.current.ReturnCursor ();
			ItemCursor.current.cursorOnObject = false;
		}
    }

}
