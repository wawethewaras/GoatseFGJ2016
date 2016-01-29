using UnityEngine;
using System.Collections;

public class ItemInGround : MonoBehaviour {

    public GameObject item;
    InventoryController theInventoryController;

    void Start() {
        theInventoryController = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            theInventoryController.AddItem(item);
            Destroy(gameObject);
        }
    }
}