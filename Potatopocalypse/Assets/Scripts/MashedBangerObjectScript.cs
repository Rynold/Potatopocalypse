using UnityEngine;
using System.Collections;

public class MashedBangerObjectScript : MonoBehaviour {
    public GameObject fry;
    float timer;

	void Start () 
    {
        timer = Time.timeSinceLevelLoad;
	}
	void Update () 
    {
        if (Time.timeSinceLevelLoad >= timer + 5)
        {
            gameObject.GetComponent<ParticleEmitter>().emit = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(this.gameObject,1f);
        }
	}
}
