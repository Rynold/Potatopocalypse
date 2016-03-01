using UnityEngine;
using System.Collections;

public class FriesWithThatController : MonoBehaviour {
    Vector3 velocity;
    public GameObject fry;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collisionInfo.collider.name == "Fireball(Clone)")
        {
            for (float i = 0; i < 100; i++)
            {
                Instantiate(fry, collisionInfo.transform.position, Quaternion.Euler(0, 0, 0));
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        velocity = new Vector3(transform.position.x, transform.position.y - 1f, -3);
        transform.position = Vector3.MoveTowards(transform.position, velocity, 1f * Time.deltaTime);
    }
}
