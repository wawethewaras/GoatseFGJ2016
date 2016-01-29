using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    MouseController theMouseController;
    public string MouseState;

    void Start () {
        theMouseController = FindObjectOfType<MouseController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && theMouseController.selectedItem == MouseState)
        {
            Debug.Log("Santa killed");
        }
    }
}
