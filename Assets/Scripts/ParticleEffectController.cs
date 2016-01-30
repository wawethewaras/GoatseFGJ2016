using UnityEngine;
using System.Collections;

public class ParticleEffectController : MonoBehaviour {

	public float duration;
    float durationCounter;
    void Start () {
        durationCounter = duration;

    }
	
	// Update is called once per frame
	void Update () {
        if (durationCounter <= 0)
        {
            Destroy(gameObject);
        }
        else {
            durationCounter -= Time.deltaTime;
        }
	}
}
