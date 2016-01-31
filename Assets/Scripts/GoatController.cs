using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoatController : MonoBehaviour {

    public string itemThatActivates;
    public GameObject sacrificePit;
    public float distance;
	public Sprite deadGoat;

	
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
			GetComponent<SpriteRenderer> ().sprite = deadGoat;
			transform.localRotation = Quaternion.Euler(0, 0, 180f);
			StartCoroutine ("credits");

        }
    }

    void KillGoat()
    {
        Debug.Log("Game over");
    }

	IEnumerator credits(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("credits");
	}
}
