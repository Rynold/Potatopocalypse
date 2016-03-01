using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad{

    public static PlayerProgress prog;
    public static PlayerUpgrades upgrades;
    public static Achievements achievements;

    public static void SaveAll()
    {
        BinaryFormatter bf = new BinaryFormatter();

        /* Saves the PlayerProgress data to a file */
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.gd");
        bf.Serialize(file, SaveLoad.prog);
        file.Close();

        /* Saves the PlayerUpgrades data to a file */
        FileStream upgradesFile = File.Create(Application.persistentDataPath + "/upgrades.gd");
        bf.Serialize(upgradesFile, SaveLoad.upgrades);
        upgradesFile.Close();

        /* Saves the Achievements data to a file */
        FileStream achievementsFile = File.Create(Application.persistentDataPath + "/achievements.gd");
        bf.Serialize(achievementsFile, SaveLoad.achievements);
        achievementsFile.Close();
    }

    public static void SavePlayerProgress()
    {
        BinaryFormatter bf = new BinaryFormatter();

        /* Saves the PlayerProgress data to a file */
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.gd");
        bf.Serialize(file, SaveLoad.prog);
        file.Close();
    }

    public static void SavePlayerUpgrades()
    {
        BinaryFormatter bf = new BinaryFormatter();

        /* Saves the PlayerUpgrades data to a file */
        FileStream upgradesFile = File.Create(Application.persistentDataPath + "/upgrades.gd");
        bf.Serialize(upgradesFile, SaveLoad.upgrades);
        upgradesFile.Close();
    }

    public static void SavePlayerAchievements()
    {
        BinaryFormatter bf = new BinaryFormatter();

        /* Saves the Achievements data to a file */
        FileStream achievementsFile = File.Create(Application.persistentDataPath + "/achievements.gd");
        bf.Serialize(achievementsFile, SaveLoad.achievements);
        achievementsFile.Close();
    }

    public static void LoadAll()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/gameSave.gd"))
        {
            /* Loads the PlayerProgress data from a file */
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.gd", FileMode.Open);
            SaveLoad.prog = (PlayerProgress)bf.Deserialize(file);
            file.Close();
        }
        else
            SaveLoad.prog = new PlayerProgress();

        if (File.Exists(Application.persistentDataPath + "/upgrades.gd"))
        {
            /* Loads the PlayerUpgrade data from a file */
            FileStream upgradesFile = File.Open(Application.persistentDataPath + "/upgrades.gd", FileMode.Open);
            SaveLoad.upgrades = (PlayerUpgrades)bf.Deserialize(upgradesFile);
            upgradesFile.Close();
        }
        else
            SaveLoad.upgrades = new PlayerUpgrades();

        if (File.Exists(Application.persistentDataPath + "/achievements.gd"))
        {
            /* Loads the Achievements data from a file */
            FileStream achievementsFile = File.Open(Application.persistentDataPath + "/achievements.gd", FileMode.Open);
            SaveLoad.achievements = (Achievements)bf.Deserialize(achievementsFile);
            achievementsFile.Close();
        }
        else
            SaveLoad.achievements = new Achievements();

        SaveAll();
    }

    public static void LoadPlayerProgress()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            /* Loads the PlayerProgress data from a file */
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.gd", FileMode.Open);
            SaveLoad.prog = (PlayerProgress)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            SaveLoad.prog = new PlayerProgress();
            SavePlayerProgress();
        }
    }

    public static void LoadPlayerUpgrades()
    {
        if (File.Exists(Application.persistentDataPath + "/upgrades.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            /* Loads the PlayerUpgrade data from a file */
            FileStream upgradesFile = File.Open(Application.persistentDataPath + "/upgrades.gd", FileMode.Open);
            SaveLoad.upgrades = (PlayerUpgrades)bf.Deserialize(upgradesFile);
            upgradesFile.Close();
        }
        else
        {
            SaveLoad.upgrades = new PlayerUpgrades();
            SavePlayerUpgrades();
        }
    }

    public static void LoadAchievements()
    {
        if (File.Exists(Application.persistentDataPath + "/achievements.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            /* Loads the Achievements data from a file */
            FileStream achievementsFile = File.Open(Application.persistentDataPath + "/achievements.gd", FileMode.Open);
            SaveLoad.achievements = (Achievements)bf.Deserialize(achievementsFile);
            achievementsFile.Close();
        }
        else
        {
            SaveLoad.achievements = new Achievements();
            SavePlayerAchievements();
        }
    }

    public static void NewGame()
    {
        SaveLoad.prog = new PlayerProgress();
        SaveLoad.upgrades = new PlayerUpgrades();
        SaveLoad.achievements = new Achievements();
        SaveAll();
    }
}
