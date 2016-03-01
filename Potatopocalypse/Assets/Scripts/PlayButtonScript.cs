using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {
    void OnMouseDown()
    {
        AdvertisementHandler.HideAds();
        Application.LoadLevel("Main Game");
    }
}
