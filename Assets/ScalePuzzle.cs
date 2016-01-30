using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScalePuzzle : MonoBehaviour {

	public int weightedTowards = 0;
	public GameObject rightSide;
	public GameObject leftSide;

    private float check = 0.5f;
    private float checkCounter;

    public void CheckSides(){
        //int rightWeight = rightSide.countWeight();

        weightedTowards = rightSide.GetComponent<ScaleSide>().countWeight() - leftSide.GetComponent<ScaleSide>().countWeight();
        //print(weightedTowards);
        //rightSide.GetComponent<ScaleSide>().resetWeight();
        //leftSide.GetComponent<ScaleSide>().resetWeight();
    }

	void Update (){
        if (checkCounter <= 0)
        {
            CheckSides();
            checkCounter = check;
        }
        else {
            checkCounter -= Time.deltaTime;
        }
	}

}
