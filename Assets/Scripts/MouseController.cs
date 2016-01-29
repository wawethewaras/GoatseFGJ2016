using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public string mouseState;

    void Start () {
        mouseState = "Empty";

    }
	
	// Update is called once per frame
	void Update () {
        //ChangeCursorImage();

    }

    public void ChangeCursorImage() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    public void ReturnCursorImage() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
