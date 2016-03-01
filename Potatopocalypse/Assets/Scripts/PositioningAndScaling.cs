using UnityEngine;
using System.Collections;

public class PositioningAndScaling : MonoBehaviour {

    GameObject house1;
    GameObject house2;
    GameObject dinoBody;
    GameObject dinoHead;
    GameObject volcano;
    GameObject smokeParticles;
    GameObject potatoGenerator;
    GameObject ground;
    RectTransform pausePanel;
    RectTransform gameOverPanel;


	void Start () {
        //Finding the object
        house1 = GameObject.Find("Left Cave");
        house2 = GameObject.Find("Right Cave");
        dinoBody = GameObject.Find("Dino Body");
        dinoHead = GameObject.Find("Dino Head");
        volcano = GameObject.Find("Background Volcano");
        smokeParticles = GameObject.Find("Smoke Particles");
        potatoGenerator = GameObject.Find("Game Control");
        ground = GameObject.Find("Ground");
        pausePanel = GameObject.Find("Pause Panel").GetComponent<RectTransform>();
        gameOverPanel = GameObject.Find("Game Over Panel").GetComponent<RectTransform>();

        //Setting the Objects position based on screen size
        house1.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0,0,7));//Screen.width/4,0,7));
        house2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,7));//(Screen.width / 4) + ((Screen.width / 4) * 2), 0, 7));
        dinoBody.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2), Screen.height - Screen.height, 7));
        dinoHead.transform.position = dinoBody.transform.position;
        volcano.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height - Screen.height,8));
        smokeParticles.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height /2 - 20, 9));
        potatoGenerator.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 7));
        ground.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height - Screen.height, 7));
        pausePanel.position = new Vector3(Screen.width, Screen.height, 0);
        gameOverPanel.position = new Vector3(-Screen.width, Screen.height, 0);
        
	}
}