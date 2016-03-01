using UnityEngine;
using System.Collections;

public class MashedBangerController : MonoBehaviour {
    Vector3 velocity;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collisionInfo.collider.name == "Fireball(Clone)")
        {
            GameObject.Find("Game Control").GetComponent<UniversalVariables>().mashedBanger = true;
            GameObject.Find("Game Control").GetComponent<UniversalVariables>().powerUpTimer = 20;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        velocity = new Vector3(transform.position.x, transform.position.y - 1f, -3);
        transform.position = Vector3.MoveTowards(transform.position, velocity, 1f * Time.deltaTime);
    }
}
