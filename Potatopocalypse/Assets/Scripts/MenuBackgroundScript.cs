using UnityEngine;
using System.Collections;

public class MenuBackgroundScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
