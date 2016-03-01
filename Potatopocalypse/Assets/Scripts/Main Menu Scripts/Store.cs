using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    /* Declaration for the upgrades that will be manipulated */
    Upgrade neck;
    Upgrade gullet;
    Upgrade jaw;

    /* Declaration for the current state of the playerProgress */
    PlayerProgress playerProg;

    /* Stores the buttons as variables */
    public Button neckButton;
    public Button gulletButton;
    public Button jawButton;

    /* Declares all the public UI elements that will be manipulated for display */
    public Text friesTextStore;
    public Text friesTextUpgrades;

    public Image necksersizeProgressBar;
    public Text necksersizeCost;

    public Image gulletOfSteamProgressBar;
    public Text gulletOfSteamCost;

    public Image jawStretchingProgressBar;
    public Text jawStretchingCost;

    float startingFries;
    int startingNeckLevel;
    int startingGulletLevel;
    int startingJawLevel;

	void Start () 
    {
        //SaveLoad.NewGame();

        startingFries = SaveLoad.prog.fries;
        startingGulletLevel = SaveLoad.upgrades.gulletOfSteam.currentLevel;
        startingJawLevel = SaveLoad.upgrades.jawStretching.currentLevel;
        startingNeckLevel = SaveLoad.upgrades.necksersize.currentLevel;

        neck = SaveLoad.upgrades.necksersize;
        gullet = SaveLoad.upgrades.gulletOfSteam;
        jaw = SaveLoad.upgrades.jawStretching;

        playerProg = SaveLoad.prog;

        friesTextStore.text = ""+playerProg.fries;
        friesTextUpgrades.text = "" + playerProg.fries;

        necksersizeProgressBar.fillAmount = 0.20f * neck.currentLevel;
        gulletOfSteamProgressBar.fillAmount = 0.20f * gullet.currentLevel;
        jawStretchingProgressBar.fillAmount = 0.20f * jaw.currentLevel;

        UpdateCostText(necksersizeCost, neck);
        UpdateCostText(gulletOfSteamCost, gullet);
        UpdateCostText(jawStretchingCost, jaw);
	}
	
	/* Describes the behaviour for all buttons in the store */
    public void OnButtonHit(UnityEngine.UI.Button b)
    {
        b.GetComponent<Image>().color = Color.green;
    }

    /* Describes the behaviour to do when the Necksersize button is hit */
    public void OnNecksersizeButtonHit()
    {
        /* If your not on the max level of the upgrade and you can afford it */
        if (neck.currentLevel < 5 && playerProg.fries >= neck.GetCost())
        {
            /* Subtract the cost of the upgrade from the players fries and add 1 to the upgrades current level */
            playerProg.fries -= neck.GetCost();
            neck.currentLevel++;

            neck.UpdatePowerLevel();

            /* Update all the UI to display the changes that just occured */
            friesTextUpgrades.text = "" + playerProg.fries;
            necksersizeProgressBar.fillAmount = 0.20f * neck.currentLevel;

            UpdateCostText(necksersizeCost, neck);
        }
    }

    /* Describes the behaviour to do when the Gullet Of Steam button is hit */
    public void OnGulletOfSteamButtonHit()
    {
        /* If your not on the max level of the upgrade and you can afford it */
        if (gullet.currentLevel < 5 && playerProg.fries >= gullet.GetCost())
        {
            /* Subtrac the cost of the upgrade from the players fries and add 1 to the upgrades current level */
            playerProg.fries -= gullet.GetCost();
            gullet.currentLevel++;

            gullet.UpdatePowerLevel();

            /* Update all the UI to display the changes that just occured */
            friesTextUpgrades.text = "" + playerProg.fries;
            gulletOfSteamProgressBar.fillAmount = 0.20f * gullet.currentLevel;

            UpdateCostText(gulletOfSteamCost, gullet);
        }
    }

    /* Describes the behaviour to do when the Jaw Stretching button is hit */
    public void OnJawStretchingButtonHit()
    {
        /* If your not on the max level of the upgrade and you can afford it */ 
        if (jaw.currentLevel < 5 && playerProg.fries >= jaw.GetCost())
        {
            /* Subtrac the cost of the upgrade from the players fries and add 1 to the upgrades current level */
            playerProg.fries -= jaw.GetCost();
            jaw.currentLevel++;

            jaw.UpdatePowerLevel();

            /* Update all the UI to display the changes that just occured */
            friesTextUpgrades.text = "" + playerProg.fries;
            jawStretchingProgressBar.fillAmount = 0.20f * jaw.currentLevel;

            UpdateCostText(jawStretchingCost, jaw);
        }
    }

    void UpdateCostText(Text t, Upgrade u)
    {
        if (u.currentLevel >= 5)
            t.text = "Finished";
        else
            t.text = "" + u.GetCost();
    }

    public void UpgradesButton()
    {
        //startingFries = SaveLoad.prog.fries;
        //startingGulletLevel = SaveLoad.upgrades.gulletOfSteam.currentLevel;
        //startingJawLevel = SaveLoad.upgrades.jawStretching.currentLevel;
        //startingNeckLevel = SaveLoad.upgrades.necksersize.currentLevel;

        //neck = SaveLoad.upgrades.necksersize;
        //gullet = SaveLoad.upgrades.gulletOfSteam;
        //jaw = SaveLoad.upgrades.jawStretching;

        //playerProg = SaveLoad.prog;

        //friesTextStore.text = "" + playerProg.fries;
        //friesTextUpgrades.text = "" + playerProg.fries;

        //necksersizeProgressBar.fillAmount = 0.20f * neck.currentLevel;
        //gulletOfSteamProgressBar.fillAmount = 0.20f * gullet.currentLevel;
        //jawStretchingProgressBar.fillAmount = 0.20f * jaw.currentLevel;

        //UpdateCostText(necksersizeCost, neck);
        //UpdateCostText(gulletOfSteamCost, gullet);
        //UpdateCostText(jawStretchingCost, jaw);
    }

    public void SaveSelection()
    {
        friesTextStore.text = "" + playerProg.fries;

        neckButton.GetComponent<Image>().color = Color.white;
        gulletButton.GetComponent<Image>().color = Color.white;
        jawButton.GetComponent<Image>().color = Color.white;

        SaveLoad.prog = playerProg;
        SaveLoad.upgrades.necksersize = neck;
        SaveLoad.upgrades.gulletOfSteam = gullet;
        SaveLoad.upgrades.jawStretching = jaw;

        SaveLoad.achievements.checkAchievements(null);
        SaveLoad.SaveAll();
    }

    public void Cancel()
    {
        SaveLoad.LoadPlayerProgress();
        SaveLoad.LoadPlayerUpgrades();

        neck = SaveLoad.upgrades.necksersize;
        gullet = SaveLoad.upgrades.gulletOfSteam;
        jaw = SaveLoad.upgrades.jawStretching;

        playerProg = SaveLoad.prog;

        friesTextStore.text = "" + playerProg.fries;
        friesTextUpgrades.text = "" + playerProg.fries;

        necksersizeProgressBar.fillAmount = 0.20f * neck.currentLevel;
        gulletOfSteamProgressBar.fillAmount = 0.20f * gullet.currentLevel;
        jawStretchingProgressBar.fillAmount = 0.20f * jaw.currentLevel;

        UpdateCostText(necksersizeCost, neck);
        UpdateCostText(gulletOfSteamCost, gullet);
        UpdateCostText(jawStretchingCost, jaw);
        

        neckButton.GetComponent<Image>().color = Color.white;
        gulletButton.GetComponent<Image>().color = Color.white;
        jawButton.GetComponent<Image>().color = Color.white;
    }
}
