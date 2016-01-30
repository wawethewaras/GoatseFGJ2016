using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    MouseController theMouseController;
    public string itemThatActivates;

    void Start () {
        theMouseController = FindObjectOfType<MouseController>();

    }	

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && ItemCursor.current.mouseState.Equals(itemThatActivates))
        {
            Debug.Log("Santa killed");
            Destroy(gameObject);
            ItemCursor.current.RemoveItem();
        }
    }
}
