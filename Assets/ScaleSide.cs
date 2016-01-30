using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScaleSide : MonoBehaviour {

    public int weight;
    public ScalePuzzle theScalePuzzle;

    void OnTriggerStay2D (Collider2D other){
        if (other.GetComponent<ItemInGround>() && !other.gameObject.transform.Equals(this.transform))
        {
            other.gameObject.transform.SetParent(this.transform);
            
        }
    }

    public int countWeight() {
        weight = 0;
        for (int i = 0; gameObject.transform.GetChildCount() > i; i++) {
            weight += transform.GetChild(i).GetComponent<ItemInGround>().weight;
        }
        return weight;

    }

}
