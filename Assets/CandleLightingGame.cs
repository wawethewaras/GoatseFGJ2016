using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CandleLightingGame : MonoBehaviour {

	public static CandleLightingGame current;
	public int candlesLit = 0;
	public List<GameObject> litCandlesList;
	public List<string> correctCandleOrder;

	void Awake(){
		current = this;
		litCandlesList = new List<GameObject> ();
	}

	public void LightCandle(GameObject candle){
		candle.GetComponent<Animator> ().SetBool ("light", true);
		candlesLit += 1;
		litCandlesList.Add(candle);

		CheckOrder ();
	}

	void Suffocate(){
		foreach (GameObject candle in litCandlesList) {
			print (candle.name);
			candle.GetComponent<Animator> ().SetBool ("light", false);
		}

		litCandlesList.Clear ();
	}

	void CheckOrder(){
		for (int i = 0; i < litCandlesList.Count; i++) {
			if (!(litCandlesList [i].name == correctCandleOrder [i])) {
				Suffocate ();
			}
		}
	}


}
