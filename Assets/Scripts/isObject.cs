using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    public string itemThatActivates;
	public GameObject affectedObject;
    public string itemInfo;
    

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState.Equals("Empty"))
        {
            ItemCursor.current.EnableInfo(itemInfo);
        }
            if (Input.GetMouseButtonDown(1) && ItemCursor.current.mouseState == itemThatActivates)
        {
            ItemCursor.current.RemoveItem();

			if (gameObject.name == "skull") {
				DropKey ();
			}
        }
    }

	void DropKey(){
		affectedObject.SetActive (true);
		affectedObject.GetComponent<BoxCollider2D> ().enabled = true;
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
