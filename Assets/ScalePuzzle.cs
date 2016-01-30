using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScalePuzzle : MonoBehaviour {

	public int weightedTowards = 0;
	public GameObject rightSide;
	public GameObject leftSide;

	private int rightWeight;
	private int leftWeight;

	public void CheckSides(){
		float leftSum = 0;
		float rightSum = 0;

		if (leftSide.GetComponent<ScaleSide> ().objectsOnSide.Count > 0) {
			foreach (GameObject weight in leftSide.GetComponent<ScaleSide>().objectsOnSide) {
				leftSum += weight.GetComponent<ScalePuzzleWeight> ().weight;
			}
		}

		if (rightSide.GetComponent<ScaleSide> ().objectsOnSide.Count > 0) {
			foreach (GameObject weight in rightSide.GetComponent<ScaleSide>().objectsOnSide) {
				rightSum += weight.GetComponent<ScalePuzzleWeight> ().weight;
			}
		}

		if (leftSum > rightSum) {
			weightedTowards = -1;
		} else if (leftSum < rightSum) {
			weightedTowards = 1;
		} else {
			weightedTowards = 0;
		}
	}

	void Update (){
		CheckSides ();
	}

}
