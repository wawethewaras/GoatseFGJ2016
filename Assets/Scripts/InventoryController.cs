using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    
    public List<GameObject> theInventory;
    public int currentItem;
    public GameObject currentItemImage;
    public GameObject inventoryUI;
	public GameObject inventoryHL;

	public List<GameObject> inventoryUIitems;
    MouseController theMouseController;


    void Start() {
        theMouseController = FindObjectOfType<MouseController>();
    }

    void Update () {
		
        UseItem();
        DropItem();
        ChangeItem();

		if (currentItem != 0) {
			inventoryHL.GetComponent<Image> ().enabled = true;
			inventoryHL.transform.position = inventoryUIitems [currentItem].transform.position;
		} else if (inventoryUIitems.Count > 0) {
			inventoryHL.GetComponent<Image> ().enabled = true;
			inventoryHL.transform.position = inventoryUIitems [0].transform.position;
		} else {
			inventoryHL.GetComponent<Image> ().enabled = false;
		}


    }
    public void AddItem(GameObject newItem)
    {
        Debug.Log("item added to inventory");
        theInventory.Add(newItem);
		GameObject tempItem = (GameObject)Instantiate(currentItemImage);
		inventoryUIitems.Add (tempItem);
        tempItem.transform.SetParent(inventoryUI.transform);
        tempItem.GetComponentInChildren<Image>().sprite = newItem.GetComponent<isItem>().itemImage;
        newItem.GetComponent<isItem>().itemsImageGameObject = tempItem;

		currentItem = theInventory.Count - 1;
    }


    public void UseItem() {
        if (Input.GetButtonDown("UseItem") && !theMouseController.mouseState.Equals("Empty"))
        {
            Debug.Log("item used");
        }
    }



    public void DropItem()
    {
        if (Input.GetButtonDown("DropItem") && theInventory.Count > 0 /*&& !theMouseController.mouseState.Equals("Empty")*/)
        {
			print ("item dropped");
			Destroy(inventoryUIitems[currentItem].gameObject);
			inventoryUIitems.RemoveAt (currentItem);

            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePosition);

			ItemCursor.current.DropItem (theInventory [currentItem].GetComponent<isItem> ().gameObject.name, theInventory [currentItem].GetComponent<isItem> ().itemImage, theInventory [currentItem].GetComponent<isItem>().itemInGround);

            //Instantiate(theInventory[currentItem].GetComponent<isItem>().itemInGround, objectPos, transform.rotation);
			theInventory.RemoveAt(currentItem);
            if (currentItem > 0)
            {
                currentItem--;
            }
        }
    }

    public void ChangeItem()
    {
        if (Input.GetButtonDown("ChangeItem"))
        {
			currentItem++;
            Debug.Log("item changed");
            if (currentItem >= theInventory.Count)
            {
                currentItem = 0;
            }

        }
    }
}
