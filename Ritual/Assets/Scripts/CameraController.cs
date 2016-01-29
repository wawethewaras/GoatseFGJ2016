using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject[] locations;
    int currentScene = 0;


    void Start()
    {
        ChangeLocation(locations[currentScene]);
    }

    void Update () {
        if (currentScene >= locations.Length) {
            currentScene = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeLocation(locations[currentScene]);
            currentScene++;
        }


    }

    void ChangeLocation(GameObject target)
    {

            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 10f);
    }
}
