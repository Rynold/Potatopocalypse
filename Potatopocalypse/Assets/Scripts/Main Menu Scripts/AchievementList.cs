using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievementList : MonoBehaviour {

    /* A dictionary to hold the description of the achievements. */
    Dictionary<string, string> descriptions;

    /* A dictionary to hold the images of the achievements */
    //Dictionary<string, Sprite> images;
    Sprite image;

    /* A dictionary to hold the spot in the array */
    Dictionary<string, int> position;

    /* The parent object for all the achievement objects. */
    public RectTransform parentAchievement;

    /* A reference to the achievement preFab */
    public RectTransform achievement;

    /* An array to store the achievement objects. */
    RectTransform[] achievementsList;

    /* Values for Creation. */
    Vector3 padding;

    void Start()
    {
        descriptions = new Dictionary<string,string>();
        FillDictionaryWithDescriptions();

        achievementsList = new RectTransform[descriptions.Count];

        /* Sets the padding to be the parents size plus five to add some space between the achievements */
        padding = new Vector3(0, parentAchievement.rect.height + 5, 0);

        position = new Dictionary<string, int>();

        int i = 0;
        foreach (KeyValuePair<string, string> entry in descriptions)// (int i = 0; i < achievementsList.Length; i++)
        {
            /* Load the sprite image */
            image = Resources.Load<Sprite>("Sprites/potato");

            /* If your on the first achievement set it to the parent object */
            if (i == 0)
            {
                achievementsList[i] = parentAchievement;

                /* Sets the title, description and image of the achievements */
                achievementsList[i].FindChild("Achievement Title").GetComponent<Text>().text = entry.Key;
                achievementsList[i].FindChild("Description Text").GetComponent<Text>().text = entry.Value;
                achievementsList[i].FindChild("Achievement Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/potato");

                if (SaveLoad.achievements.list[entry.Key])
                    achievementsList[i].FindChild("Achievement Image").GetComponent<Image>().color = Color.white;

                /* Adds i into the position dictionary */
                position.Add(entry.Key, i);
            }
            else
            {
                /* Instantiates a new achievement as a rect transfrom */
                achievementsList[i] = (RectTransform)Instantiate(achievement);

                /* sets the new achievement to be a child of the previouse one */
                achievementsList[i].SetParent(achievementsList[i - 1], false);

                /* Sets the new achievements position to be the parents plus our padding */
                achievementsList[i].position = achievementsList[i].parent.position - padding;

                /* Sets the title, description and image of the achievements */
                achievementsList[i].FindChild("Achievement Title").GetComponent<Text>().text = entry.Key;
                achievementsList[i].FindChild("Description Text").GetComponent<Text>().text = entry.Value;
                achievementsList[i].FindChild("Achievement Image").GetComponent<Image>().sprite = image;

                if (SaveLoad.achievements.list[entry.Key])
                    achievementsList[i].FindChild("Achievement Image").GetComponent<Image>().color = Color.white;

                /* Adds i into the position dictionary */
                position.Add(entry.Key, i);
            }

            i++;
        }
    }

    void FillDictionaryWithDescriptions()
    {
        foreach (KeyValuePair<string, bool> entry in SaveLoad.achievements.list)
        {
            if (entry.Key == "Hit Streak 10")
                descriptions.Add(entry.Key, "Don't miss 10 times in a row.");
            if (entry.Key == "Hit Streak 20")
                descriptions.Add(entry.Key, "Don't miss 20 times in a row.");
            if (entry.Key == "My First Upgrade")
                descriptions.Add(entry.Key, "Purchase an upgrade from the store.");
            if (entry.Key == "Fully Upgraded")
                descriptions.Add(entry.Key, "Purchase all upgrades from the store.");
        }
        
    }

    void CheckAchievements()
    {
        foreach (KeyValuePair<string, bool> entry in SaveLoad.achievements.list)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
            if (entry.Value == true)
                achievementsList[position[entry.Key]].FindChild("Achievement Image").GetComponent<Image>().color = Color.white;
        }
    }


    void Update()
    {
        CheckAchievements();
    }
}
