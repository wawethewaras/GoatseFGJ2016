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

    public Texture2D cursorObjectTexture;
	public Texture2D cursorGrabTexture;
	public Texture2D cursorBasicTexture;

	public Texture2D currentCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot;
    public GameObject infoText;
    public float infoTextDuration;
    private float infoTextDurationCounter;

	private bool grabbing;
	public bool cursorOnObject;

    void Awake(){
		current = this;


    }

	void Start(){
		hoveringObject = new GameObject ();
		hoveringObject.AddComponent<SpriteRenderer>();
		hoveringObject.name = "HoveringObject";
		hoveringObject.GetComponent<SpriteRenderer> ().sortingLayerName = "UI";
        mouseState = "Empty";

		currentCursorTexture = cursorBasicTexture;

		hotSpot = new Vector2 (0.1f, 0.1f);

		ReturnCursor ();
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
        
		if (currentCursorTexture == cursorObjectTexture && Input.GetMouseButton(0)){
			print ("lol");
			GrabCursor ();
		}
    }

    public void HoveringItem(string pname, Sprite psprite, GameObject itemObject, string iMouseState){
		GrabCursor ();
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

    public void ObjectCursor() {
        if (ItemCursor.current.mouseState.Equals("Empty"))
        {
			currentCursorTexture = cursorObjectTexture;
            Cursor.SetCursor(cursorObjectTexture, hotSpot, cursorMode);
        }
    }
    public void ReturnCursor()
    {
		currentCursorTexture = cursorBasicTexture;
        Cursor.SetCursor(cursorBasicTexture, hotSpot, cursorMode);
    }

    public void EnableInfo(string info) {
        infoText.SetActive(true);
        infoText.GetComponentInChildren<Text>().text = info;
        infoTextDurationCounter = infoTextDuration;
    }

	private void GrabCursor(){
		currentCursorTexture = cursorGrabTexture;
		Cursor.SetCursor(cursorGrabTexture, hotSpot, cursorMode);
	}
}

