using UnityEngine;
using System.Collections;

public class isLever : MonoBehaviour {

    public bool activated;
    public Sprite[] sprites;
    SpriteRenderer mySpriteRenderer;

    void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0) && ItemCursor.current.mouseState.Equals("Empty"))
        {
            if (activated) {
                activated = false;
                mySpriteRenderer.sprite = sprites[0];
            }
            else if (!activated)
            {
                activated = true;
                mySpriteRenderer.sprite = sprites[1];
            }
        }
    }
}
