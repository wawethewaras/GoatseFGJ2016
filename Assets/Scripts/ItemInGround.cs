using UnityEngine;
using System.Collections;

public class ItemInGround : MonoBehaviour {

    public GameObject item;
    InventoryController theInventoryController;

    void Start() {
        theInventoryController = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
            ItemCursor.current.ChangeCursor();
        }
        if (Input.GetMouseButtonDown(0))
        {
            theInventoryController.AddItem(item);
            Destroy(gameObject);
        }
    }

    void OnMouseExit()
    {
        ItemCursor.current.ReturnCursor();
    }
}