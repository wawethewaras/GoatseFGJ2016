using UnityEngine;
using System.Collections;

public class ItemCursor : MonoBehaviour {

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

	}

	public void DropItem(string pname, Sprite psprite, GameObject itemObject){
		hoveringObject.GetComponent<SpriteRenderer>().sprite = psprite;
		name = pname;
		sprite = psprite;
		objectToDrop = itemObject;
		//hoveringType = "item";
	}

	void Update(){
		mousePos = Input.mousePosition;
		mousePos [2] = -Camera.main.transform.position.z;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		hoveringObject.transform.position = mousePos;

		if (Input.GetMouseButtonDown (0) && hoveringObject.GetComponent<SpriteRenderer> ().sprite != null /*&& hoveringType == "emp"*/) {
			GameObject placedObject = (GameObject)Instantiate (objectToDrop, mousePos, Quaternion.identity);

			hoveringType = null;
			hoveringObject.GetComponent<SpriteRenderer> ().sprite = null;

		}
	}
}

