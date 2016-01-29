using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    
    public List<GameObject> theInventory;
    public int currentItem;
    public GameObject currentItemImage;
    public GameObject inventoryUI;

    void Start () {
	
	}
	
	void Update () {
        UseItem();
        DropItem();
        ChangeItem();

    }
    public void AddItem(GameObject newItem)
    {
        Debug.Log("item added to inventory");
        theInventory.Add(newItem);
        GameObject tempImage = (GameObject)Instantiate(currentItemImage);
        tempImage.transform.SetParent(inventoryUI.transform);
        tempImage.GetComponentInChildren<Image>().sprite = newItem.GetComponent<isItem>().itemImage;
        newItem.GetComponent<isItem>().itemsImageGameObject = tempImage;
    }

    public void UseItem() {
        if (Input.GetButtonDown("UseItem"))
        {
            Debug.Log("item used");
        }
    }

    public void DropItem()
    {
        if (Input.GetButtonDown("DropItem") && theInventory.Count > 0)
        {
            Debug.Log("item removed");
            Destroy(theInventory[currentItem].GetComponent<isItem>().itemsImageGameObject);
            Instantiate(theInventory[currentItem].GetComponent<isItem>().itemInGround, transform.position,transform.rotation);
            theInventory.Remove(theInventory[currentItem]);
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
            Debug.Log("item changed");
            if (currentItem > theInventory.Count)
            {
                currentItem = 0;
            }
            currentItem++;
            //currentItemImage.sprite = theInventory[currentItem].GetComponent<isItem>().itemImage;
        }
    }
}
