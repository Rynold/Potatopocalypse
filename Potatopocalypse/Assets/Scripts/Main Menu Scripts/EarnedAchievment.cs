using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EarnedAchievment : MonoBehaviour {

    public Sprite image;
    public Text title;

	/* A Vector3 to store the in view position and A Vector3 to store the out of view position */
    public Vector3 inViewPosition;
    Vector3 outOfViewPosition;
    public Vector3 newPosition;

    float stayTime;
    public float startTime;

	void Start () 
    {
        inViewPosition = new Vector3(Screen.width, Screen.height, 0);
        outOfViewPosition = new Vector3(Screen.width, Screen.height + GetComponent<RectTransform>().rect.height + 5, 0);
        newPosition = outOfViewPosition;
        startTime = -5.0f;
        stayTime = 3.0f;
	}
	
	
	void Update () 
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, 5.5f * Time.deltaTime);

        if (newPosition == inViewPosition)
        {
            if (Time.timeSinceLevelLoad >= (startTime + stayTime))
                newPosition = outOfViewPosition;
        }
	}
}
