using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    
    float highScore;
    UniversalVariables uniVar;
    UnityEngine.UI.Text scoreText;

	void Start () 
    {
        SaveLoad.LoadPlayerProgress();
        highScore = SaveLoad.prog.highScore;

        scoreText = GameObject.Find("Score Text").GetComponent<UnityEngine.UI.Text>();
        uniVar = GetComponent<UniversalVariables>();
	}
	

	void Update () 
    {
        scoreText.text = "" + uniVar.score;

        if (uniVar.score > highScore)
        {
            SaveLoad.prog.highScore = uniVar.score;
            SaveLoad.SavePlayerProgress();
        }
        Debug.Log("HighScore: " + SaveLoad.prog.highScore);
	}
}
