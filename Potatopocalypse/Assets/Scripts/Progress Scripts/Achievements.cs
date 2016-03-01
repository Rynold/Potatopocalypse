using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Achievements
{
    public Dictionary<string, bool> list;
    public delegate void MultiDelegete(UniversalVariables uniVar);
    public MultiDelegete checkAchievements;
    public bool change;
    public string changeName;

    public Achievements()
    {
        list = new Dictionary<string,bool>();
        CreateList();

        checkAchievements += HitStreak10;
        checkAchievements += HitStreak20;
        checkAchievements += MyFirstUpgrade;
        checkAchievements += FullyUpgraded;

        changeName = "";
        change = false;
    }

    void CreateList()
    {
        list.Add("Hit Streak 10", false);
        list.Add("Hit Streak 20", false);

        list.Add("My First Upgrade", false);
        list.Add("Fully Upgraded", false);
    }

    //public void CheckAchievements(UniversalVariables uniVar)
    //{
    //    Dictionary<string, bool> buffer = new Dictionary<string, bool>(list);

    //    foreach (KeyValuePair<string, bool> entry in buffer)
    //    {
    //        if (entry.Key == "Hit Streak 10" && entry.Value != true)
    //            HitStreak10(uniVar);
    //        if (entry.Key == "Hit Streak 20" && entry.Value != true)
    //            HitStreak20(uniVar);
    //        if (entry.Key == "My First Upgrade" && entry.Value != true)
    //            MyFirstUpgrade(uniVar);
    //        if (entry.Key == "Fully Upgrade" && entry.Value != true)
    //            FullyUpgraded(uniVar);
    //    }
    //}

    void HitStreak10(UniversalVariables uniVar)
    {
        if (uniVar == null)
            return;

        if (uniVar.maxHitStreak >= 10)
        {
            list["Hit Streak 10"] = true;
            change = true;
            changeName = "Hit Streak 10";
            checkAchievements -= HitStreak10;
        }
    }
    void HitStreak20(UniversalVariables uniVar)
    {
        if (uniVar == null)
            return;

        if (uniVar.maxHitStreak >= 20)
        {
            list["Hit Streak 20"] = true;
            change = true;
            changeName = "Hit Streak 20";
            checkAchievements -= HitStreak20;
        }
    }

    void MyFirstUpgrade(UniversalVariables uniVar)
    {
        if (SaveLoad.upgrades.necksersize.currentLevel > 0 ||
            SaveLoad.upgrades.gulletOfSteam.currentLevel > 0 ||
            SaveLoad.upgrades.jawStretching.currentLevel > 0)
        {
            list["My First Upgrade"] = true;
            changeName = "My First Upgrade";
            change = true;
            checkAchievements -= MyFirstUpgrade;
        }
    }
   
    void FullyUpgraded(UniversalVariables uniVar)
    {
        if (SaveLoad.upgrades.necksersize.currentLevel >= 5 &&
            SaveLoad.upgrades.gulletOfSteam.currentLevel >= 5 &&
            SaveLoad.upgrades.jawStretching.currentLevel >= 5)
        {
            list["Fully Upgraded"] = true;
            changeName = "Fully Upgraded";
            change = true;
            checkAchievements -= FullyUpgraded;
        }
    }
}
