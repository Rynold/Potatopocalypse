using UnityEngine;
using System.Collections;

public class FryController : MonoBehaviour {

    Vector3 velocity;
    float timeCreated;
    Vector3 gravity;
    UniversalVariables uniVar;

	void Start ()
    {
        gravity = new Vector3(0f, -0.005f, 0f);
        uniVar = GameObject.Find("Game Control").GetComponent<UniversalVariables>();
        uniVar.score++;
        uniVar.sessionFries++;
        velocity = new Vector3(Random.Range(-0.025f, 0.025f), Random.Range(0.025f,0.10f));
        timeCreated = Time.timeSinceLevelLoad;
	}
	
	void Update () {
        velocity += gravity;
        transform.position = transform.position + velocity;
        if (Time.timeSinceLevelLoad >= timeCreated + 1f)
        {
            Destroy(this.gameObject);
        }
	}
}
