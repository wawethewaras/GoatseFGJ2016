using UnityEngine;
using System.Collections;

public class ItemCursor : MonoBehaviour {
    public string mouseState;

    private GameObject hoveringObject;
	public GameObject itemGameObject;
	private string hoveringType;
	private Vector3 mousePos;
	private string name;
	private Sprite sprite;
	private GameObject objectToDrop;

	public static ItemCursor current;

	void Awake(){
		current = this;


    }

	void Start(){
		hoveringObject = new GameObject ();
		hoveringObject.AddComponent<SpriteRenderer>();
		hoveringObject.name = "HoveringObject";
		hoveringObject.GetComponent<SpriteRenderer> ().sortingLayerName = "UI";
        mouseState = "Empty";

    }

	public void HoveringItem(string pname, Sprite psprite, GameObject itemObject, string iMouseState){
		hoveringObject.GetComponent<SpriteRenderer>().sprite = psprite;
		name = pname;
		sprite = psprite;
		objectToDrop = itemObject;
        mouseState = iMouseState;
        //hoveringType = "item";
    }

	void Update(){
		mousePos = Input.mousePosition;
		mousePos [2] = -Camera.main.transform.position.z;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		hoveringObject.transform.position = mousePos;

        DropItem();
        //UseItem();

    }
    /*
    void UseItem() {
        if (Input.GetMouseButtonDown(1) && !mouseState.Equals("Empty"))
        {
            Debug.Log("item used");
            hoveringType = null;
            hoveringObject.GetComponent<SpriteRenderer>().sprite = null;
            mouseState = "Empty";
        }
    }*/
    void DropItem() {
        if (Input.GetMouseButtonDown(0) && hoveringObject.GetComponent<SpriteRenderer>().sprite != null && !mouseState.Equals("Empty")/*&& hoveringType == "emp"*/)
        {

            GameObject placedObject = (GameObject)Instantiate(objectToDrop, mousePos, Quaternion.identity);

            hoveringType = null;
            hoveringObject.GetComponent<SpriteRenderer>().sprite = null;
            mouseState = "Empty";

        }
    }
    public void RemoveItem()
    {
        hoveringType = null;
        hoveringObject.GetComponent<SpriteRenderer>().sprite = null;
        mouseState = "Empty";
    }
}

