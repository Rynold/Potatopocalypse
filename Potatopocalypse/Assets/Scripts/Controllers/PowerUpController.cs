using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    Vector3 velocity;
	
	void Update () {
        velocity = new Vector3(transform.position.x,transform.position.y - 2,-3);
        transform.position = Vector3.MoveTowards(transform.position, velocity, 2f * Time.deltaTime);
    }
}
