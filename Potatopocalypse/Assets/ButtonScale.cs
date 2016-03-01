using UnityEngine;
using System.Collections;

public class ButtonScale : MonoBehaviour
{
    //Rect rect;
	void Start () 
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 2);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 10);
	}
}
