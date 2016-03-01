using UnityEngine;
using System.Collections;

public class PositioningComponents : MonoBehaviour {

    public RectTransform mainPanel;
    public RectTransform playPanel;
    public RectTransform upgradesPanel;
    public RectTransform storePanel;
    public RectTransform skinsPanel;
    public RectTransform achievementsPanel;

    public RectTransform[] buttons;

    public RectTransform neckersizePanel;
    public RectTransform gulletOfSteamPanel;
    public RectTransform jawStretchingPanel;

	// Use this for initialization
	void Start ()  
    {
        mainPanel.position = new Vector3(0, Screen.height, 0);
        playPanel.position = new Vector3(Screen.width, Screen.height, 0);
        storePanel.position = new Vector3(-Screen.width, Screen.height, 0);
        upgradesPanel.position = new Vector3(-Screen.width, Screen.height * 2, 0);
        skinsPanel.position = new Vector3(-Screen.width * 2, Screen.height, 0);
        achievementsPanel.position = new Vector3(0, 0, 0);

	}

    void FixedUpdate()
    {

    }
}
