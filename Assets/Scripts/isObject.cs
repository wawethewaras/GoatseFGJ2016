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
            ItemCursor.current.EnableInfo(itemInfo);
        }


        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState == itemThatActivates)
    	{
            ItemCursor.current.RemoveItem();

			if (gameObject.name == "Skull") {
				DropKey ();
			}
            if (gameObject.name == "EvilSanta")
            {
                OpenDoor();
            }
            if (gameObject.tag == "Goat")
            {
                //KillGoat();
            }
            if (gameObject.name == "candle" || gameObject.name == "candle1" || gameObject.name == "candle2" || gameObject.name == "candle3" || gameObject.name == "candle4") {
				CandleLightingGame.current.LightCandle (gameObject);
			}

			if (gameObject.name == "Rope") {
				print ("cutrope");
				CutRope ();
			}

			if (gameObject.name == "SacrificeCircle") {
				SacrificePuzzle.goatPlaced = true;
				print ("goatplaced");
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
        transform.position = new Vector3(transform.position.x -10f, transform.position.y, transform.position.z);
    }
    void KillGoat() {
        Debug.Log("Game over");
    }

	void CutRope(){
		affectedObject.GetComponent<ItemInGround> ().enabled = true;
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
