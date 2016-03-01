using UnityEngine;
using System.Collections;

[System.Serializable]
public class Upgrade
{
    int maxLevel;
    public int currentLevel;
    float[] cost;
    float levelMultiplyer;
    public float power;
    public bool percentage;

    public Upgrade()
    {
        percentage = true;
        maxLevel = 5;
        currentLevel = 0;
        levelMultiplyer = 5;
        power = currentLevel * levelMultiplyer;
        cost = new float[5];


        cost[0] = 1000;
        cost[1] = 5000;
        cost[2] = 10000;
        cost[3] = 20000;
        cost[4] = 50000;
    }

    public void UpdatePowerLevel()
    {
        power = currentLevel * levelMultiplyer;
    }

    public float GetCost()
    {
        return cost[currentLevel];
    }
}
