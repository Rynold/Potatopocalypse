using UnityEngine;
using System.Collections;

public class PowerUPGenerator : MonoBehaviour {

    public GameObject[] powerUps;
    float currentTime;
    float previousTime;

    void Start () 
    {
        currentTime = 0;
        previousTime = currentTime;
	}
	
	void Update () {
        currentTime = Time.timeSinceLevelLoad;
        if (currentTime > previousTime + 30)
        {
            previousTime = currentTime;
            Instantiate(powerUps[(int)Mathf.Floor(Random.Range(0, powerUps.Length))], Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50, Screen.width - 50), Screen.height, 7)), Quaternion.identity);
        }
	}
}
