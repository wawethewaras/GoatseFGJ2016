using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemCursor : MonoBehaviour {
    public string mouseState;

    private GameObject hoveringObject;
	private string hoveringType;
	private Vector3 mousePos;
	private string name;
	private Sprite sprite;
	private GameObject objectToDrop;

	public static ItemCursor current;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject infoText;
    public float infoTextDuration;
    private float infoTextDurationCounter;

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

    void Update()
    {
        if (infoTextDurationCounter >= 0)
        {
            infoTextDurationCounter -= Time.deltaTime;
        }
        else {
            infoText.SetActive(false);
        }

        mousePos = Input.mousePosition;
        mousePos[2] = -Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        hoveringObject.transform.position = mousePos;

        DropItem();
        //UseItem();
    }

    public void HoveringItem(string pname, Sprite psprite, GameObject itemObject, string iMouseState){
		hoveringObject.GetComponent<SpriteRenderer>().sprite = psprite;
		name = pname;
		sprite = psprite;
		objectToDrop = itemObject;
        mouseState = iMouseState;
        //hoveringType = "item";
    }

    void DropItem() {
        if (Input.GetMouseButtonDown(0)/*Input.GetButtonDown("DropItem")*/ && hoveringObject.GetComponent<SpriteRenderer>().sprite != null && !mouseState.Equals("Empty")/*&& hoveringType == "emp"*/)
        {

            GameObject placedObject = (GameObject)Instantiate(objectToDrop, mousePos, Quaternion.identity);

            hoveringType = null;
            hoveringObject.GetComponent<SpriteRenderer>().sprite = null;
            mouseState = "Empty";

			AudioPlayer.current.PlaySoundClip ("dropItem");

        }
    }
    public void RemoveItem()
    {
        hoveringType = null;
        hoveringObject.GetComponent<SpriteRenderer>().sprite = null;
        mouseState = "Empty";
    }

    public void ChangeCursor() {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
    public void ReturnCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void EnableInfo(string info) {
        infoText.SetActive(true);
        infoText.GetComponentInChildren<Text>().text = info;
        infoTextDurationCounter = infoTextDuration;
    }
}

