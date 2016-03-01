using UnityEngine;
using System.Collections;

public class RestartButtonScript : MonoBehaviour {

	void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
        gameObject.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - gameObject.GetComponent<GUITexture>().pixelInset.width / 2, Screen.height / 2, 128, 58);
	}
    void OnMouseDown()
    {
        Application.LoadLevel("Main Game");
    }
}
