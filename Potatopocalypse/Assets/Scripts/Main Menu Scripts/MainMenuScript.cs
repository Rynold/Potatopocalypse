using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public RectTransform topPanel;

    Vector3 newPosition;
    Vector3 startPosition;
    Vector3 downTranslation;
    Vector3 rightTranslation;

    public RectTransform earnedPanel;

	
	void Start () 
    {
        SaveLoad.NewGame();
        SaveLoad.LoadAll();
        rightTranslation = new Vector3(-Screen.width, 0, 0);
        downTranslation = new Vector3(0, Screen.height, 0);
        startPosition = topPanel.position;
        newPosition = topPanel.position;
	}
	
	/* Primaraly used to Lerp the panels */
	void Update ()
    {
        topPanel.transform.position = Vector3.Lerp(topPanel.transform.position, newPosition, 5.5f * Time.deltaTime);
        

        if (SaveLoad.achievements.change == true)
        {
            /* Sets the newPosition of the earned panel to be withing view */
            earnedPanel.GetComponent<EarnedAchievment>().newPosition = earnedPanel.GetComponent<EarnedAchievment>().inViewPosition;

            /* Sets the image to be that of the achievement earned */
            earnedPanel.FindChild("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/potato");

            /* Sets the title to be that of the achievement earned */
            earnedPanel.FindChild("Achievement Title").GetComponent<Text>().text = SaveLoad.achievements.changeName;

            earnedPanel.GetComponent<EarnedAchievment>().startTime = Time.timeSinceLevelLoad;

            /* Saves the players achievements then set change to be false */
            SaveLoad.SavePlayerAchievements();
            SaveLoad.achievements.change = false;
        }

	}

    /* Sets the newPosition to be to the right by the size of the screen */
    public void RightTranslation()
    {
        newPosition += rightTranslation;
    }

    /* Sets the newPosition to be to the Left by the size of the screen */
    public void LeftTranslation()
    {
        newPosition -= rightTranslation;
    }

    /* Sets the newPosition to be Down by the size of the screen */
    public void DownTranslation()
    {
        newPosition += downTranslation;
    }

    /* Sets the newPosition to be Up by the size of the screen */
    public void UpTranslation()
    {
        newPosition -= downTranslation;
    }

    /* Sets the newPosition to be to the position of the main menu */
    public void MainMenu()
    {
        newPosition = startPosition;
    }

    /* Starts the game according to the players choice */
    public void StartGame()
    {
        Application.LoadLevel("Endless Survival");
    }
}
