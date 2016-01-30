using UnityEngine;
using System.Collections;

public class ItemInGround : MonoBehaviour {

    public GameObject item;
    public GameObject particleEffect;
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
            Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnMouseExit()
    {
        ItemCursor.current.ReturnCursor();
    }
}