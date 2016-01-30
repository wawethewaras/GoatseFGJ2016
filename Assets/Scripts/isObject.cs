using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    public string itemThatActivates;
	

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) /*Input.GetButtonDown("UseItem")*/&& ItemCursor.current.mouseState.Equals(itemThatActivates))
        {
            Debug.Log("Santa killed");
            Destroy(gameObject);
            ItemCursor.current.RemoveItem();
        }
    }
}
