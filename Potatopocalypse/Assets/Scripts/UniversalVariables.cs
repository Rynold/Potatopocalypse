using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UniversalVariables : MonoBehaviour {

    public float fries;
    public float score;
    public float lives;
    public float multiplyer;
    float currentTime;
    float previousTime;
    GameObject houseLeft;
    GameObject houseRight;
    GameObject dino;
    bool hasDied;
    public bool mashedBanger;
    public bool crippleChip;
    public bool hashseeker;
    public float powerUpTimer;
    RectTransform mainPanel;
    public Vector3 startPosition;
    public Vector3 newPos;

    public bool paused;
    public Sprite[] image;
    public UnityEngine.UI.Button pauseButton;

    public int hitStreak;
    public int maxHitStreak;
    public RectTransform earnedPanel;
    public float sessionFries;

    public float necksersizePower;
    public float jawStretchingPower;
    public float gulletOfSteamPower;

	void Start () 
    {

        SaveLoad.LoadAll();

        necksersizePower = SaveLoad.upgrades.necksersize.power;
        jawStretchingPower = SaveLoad.upgrades.jawStretching.power;
        gulletOfSteamPower = SaveLoad.upgrades.gulletOfSteam.power;

        sessionFries = 0.0f;

        mainPanel = GameObject.Find("Main Panel").GetComponent<RectTransform>();

        mashedBanger = false;
        crippleChip = false;
        hashseeker = false;
        hasDied = false;
        multiplyer = 1;
        lives = 3;
        score = 0;
        currentTime = Mathf.Floor(Time.timeSinceLevelLoad);
        previousTime = currentTime;
        houseLeft = GameObject.Find("Left Cave");
        houseRight = GameObject.Find("Right Cave");
        dino = GameObject.Find("Dino Head");
        hitStreak = 0;
        startPosition = mainPanel.position;
        newPos = mainPanel.position;

        StartCoroutine("CheckAchievements");

        paused = false;
        pauseButton = GameObject.Find("Pause Button").GetComponent<UnityEngine.UI.Button>();
	}

    void Update()
    {

        Debug.Log("Position: " + mainPanel.position + " || New Position: " + newPos);
        Debug.Log("Lives: " + lives);

        mainPanel.position = Vector3.Lerp(mainPanel.transform.position, newPos, 5.5f * Time.deltaTime);

        currentTime = Mathf.Floor(Time.timeSinceLevelLoad);
        if(dino.GetComponent<DinoController>().isAlive)
        {
            if (currentTime > previousTime)
            {
                powerUpTimer--;
                previousTime = currentTime;
                score += 1;
            }
        }
        if (multiplyer > 5)
            multiplyer = 5;

        if (lives == 2)
            houseLeft.GetComponent<HouseScript>().Destroy();
        else if (lives == 1)
            houseRight.GetComponent<HouseScript>().Destroy();
        else if (lives <= 0)
        {
            dino.GetComponent<DinoController>().isAlive = false;
            if (!hasDied)
            {
                newPos = mainPanel.position + new Vector3(Screen.width, 0, 0);
                hasDied = true;
                Debug.Log("Prog fries: " + SaveLoad.prog.fries + " | sessionFries: " + sessionFries);
                SaveLoad.prog.fries += sessionFries;
                Debug.Log("Prog Fries: " + SaveLoad.prog.fries);
                SaveLoad.SaveAll();
            }
            lives = 0;
        }
        


        if (powerUpTimer <= 0)
        {
            mashedBanger = false;
            hashseeker = false;
            crippleChip = false;
            powerUpTimer = 0;
        }

        if (hitStreak > maxHitStreak)
            maxHitStreak = hitStreak;


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

    public void MainMenuButton()
    {
        paused = false;
        Time.timeScale = 1;
        Application.LoadLevel("Main Menu");
    }

    public void RestartButton()
    {
        Application.LoadLevel("Endless Survival");
    }

    public void ResumeButton()
    {
        newPos = startPosition;

        Time.timeScale = 1;
        paused = false;
        pauseButton.image.sprite = image[0];
    }

    public void OnPauseButtonClick()
    {
        mainPanel.position = startPosition - new Vector3(Screen.width, 0, 0);
        newPos = mainPanel.position;
        Time.timeScale = 0;
        paused = true;
        pauseButton.image.sprite = image[1];
    }

    IEnumerator CheckAchievements()
    {
        while (lives > 0)
        {
            Debug.Log("Check Achievements");

            if(SaveLoad.achievements.checkAchievements != null)
                SaveLoad.achievements.checkAchievements(this);

            yield return new WaitForSeconds(1.0f);
        }
    }
}
