using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerProgress{


    public static PlayerProgress current;
    public float highScore;
    public int levelProgress;
    public float fries;

    public PlayerProgress()
    {
        highScore = 0.0f;
        levelProgress = 1;
        fries = 10000000.0f;
    }
}
