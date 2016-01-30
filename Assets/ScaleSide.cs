using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScaleSide : MonoBehaviour {

	public List<GameObject> objectsOnSide;

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Weight") {
			objectsOnSide.Add (coll.gameObject);

			GetComponentInParent<ScalePuzzle> ().CheckSides ();

		}
	}

	void OnTriggerExit2D (Collider2D coll){
		if (coll.tag == "Weight") {
			objectsOnSide.Remove (coll.gameObject);
		
			GetComponentInParent<ScalePuzzle> ().CheckSides ();
		}
	}

	public void RemoveObject(GameObject obj){
		objectsOnSide.Remove (obj);

		GetComponentInParent<ScalePuzzle> ().CheckSides ();
	}

}
