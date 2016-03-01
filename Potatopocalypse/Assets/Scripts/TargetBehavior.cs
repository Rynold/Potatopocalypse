using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

    float rotationVelocity;
    float scalingVelocity;
    GameObject dino;
	
	void Start () {
        dino = GameObject.Find("Dino Head");
        rotationVelocity = 1f;
        scalingVelocity = 0.01f;
        transform.position = dino.GetComponent<DinoController>().targetObjLocation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.localScale.x >= 2)
        {
            scalingVelocity = -scalingVelocity;
        }
        else if(transform.localScale.x <= 1)
            scalingVelocity = +scalingVelocity;

        transform.localScale += new Vector3(scalingVelocity, scalingVelocity, 0);
        transform.Rotate(new Vector3(0,0,rotationVelocity));

        if (dino.GetComponent<DinoController>().isRotating == false || dino.GetComponent<DinoController>().targetObjLocation != transform.position || !dino.GetComponent<DinoController>().isAlive)
            Destroy(this.gameObject);
	}
}
