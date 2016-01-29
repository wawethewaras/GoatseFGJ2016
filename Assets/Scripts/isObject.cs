using UnityEngine;
using System.Collections;

public class isObject : MonoBehaviour {

    MouseController theMouseController;
    public string MouseState;

    void Start () {
        theMouseController = FindObjectOfType<MouseController>();

    }	

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && theMouseController.mouseState.Equals(MouseState))
        {
            Debug.Log("Santa killed");
            Destroy(gameObject);
        }
    }
}
