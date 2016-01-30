using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    public string itemThatActivates;
	public GameObject affectedObject;
	

    void OnMouseOver()
    {
		
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
	
}
