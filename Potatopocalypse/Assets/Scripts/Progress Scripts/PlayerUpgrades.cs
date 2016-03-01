using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerUpgrades{

    public static PlayerUpgrades currentUpgrades;
    public Upgrade necksersize;
    public Upgrade gulletOfSteam;
    public Upgrade jawStretching;

    public PlayerUpgrades()
    {
        necksersize = new Upgrade();
        gulletOfSteam = new Upgrade();
        jawStretching = new Upgrade();
    }
}
