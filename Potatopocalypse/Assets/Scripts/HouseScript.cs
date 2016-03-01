using UnityEngine;
using System.Collections;

public class HouseScript : MonoBehaviour {

    public GameObject fire;
    public Sprite destroyed;
    bool hasDestroyed;

	void Start ()
    {
        hasDestroyed = false;
        //if (name == "Left Cave")
        //{
        //    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
        //        216 / 2 - ((256-216) / 2),
        //        130 / 2,
        //        7));
        //}
        //else
        //    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
        //        Screen.width - (216 / 2 - ((256-216) / 2)),
        //        130 / 2,
        //        7));
	}

    public void Destroy()
    {
        if (!hasDestroyed)
        {
            GetComponent<SpriteRenderer>().sprite = destroyed;
            Instantiate(fire, transform.position, Quaternion.identity);
            hasDestroyed = true;
        }
    }
}
