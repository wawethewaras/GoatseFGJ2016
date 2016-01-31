using UnityEngine;
using System.Collections;

public class ItemInGround : MonoBehaviour {

    public GameObject item;
    public GameObject particleEffect;
    public int weight;
    public bool weightCounted;
    public bool isOnScale;
    public bool canPickUp;
    InventoryController theInventoryController;

    void Start() {
        theInventoryController = FindObjectOfType<InventoryController>();
        weightCounted = false;
        isOnScale = false;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
            ItemCursor.current.ObjectCursor();
        }
        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState.Equals("Empty") && canPickUp)
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