using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {
    
    public List<isItem> theInventory;
    public int currentItem;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void UseItem() {
        Debug.Log("item used");
    }

    public void DropItem()
    {
        theInventory.Remove(theInventory[currentItem]);
    }

    public void ChangeItem()
    {
        if (currentItem > theInventory.Count) {
            currentItem = 0;
        }
        currentItem++;
    }
}
