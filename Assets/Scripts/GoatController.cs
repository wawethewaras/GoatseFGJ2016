using UnityEngine;
using System.Collections;

public class GoatController : MonoBehaviour {

    public string itemThatActivates;
    public GameObject sacrificePit;
    public float distance;


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        sacrificePit = GameObject.FindGameObjectWithTag("SacrificePit");

        if (sacrificePit != null && Vector3.Distance(transform.position, sacrificePit.transform.position) <= distance)
        {
            SacrificePuzzle.goatPlaced = true;
        }
        else {
            SacrificePuzzle.goatPlaced = false;
        }
    }
    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState == itemThatActivates && SacrificePuzzle.goatPlaced)
        {
            Debug.Log("Game over");
        }
    }

    void KillGoat()
    {
        Debug.Log("Game over");
    }
}
