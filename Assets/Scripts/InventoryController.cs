using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    
    public List<GameObject> theInventory;
    public int currentItem;
    public Image currentItemImage;

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
        currentItemImage.sprite = theInventory[currentItem].GetComponent<isItem>().itemImage;
    }

    public void UseItem() {
        if (Input.GetButtonDown("UseItem"))
        {
            Debug.Log("item used");
        }
    }

    public void DropItem()
    {
        if (Input.GetButtonDown("DropItem"))
        {
            Debug.Log("item removed");
            Instantiate(theInventory[currentItem].GetComponent<isItem>().itemInGround, transform.position,transform.rotation);
            theInventory.Remove(theInventory[currentItem]);
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
        }
    }
}
