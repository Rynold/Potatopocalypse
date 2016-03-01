using UnityEngine;
using System.Collections;

public class MultiplyerControl : MonoBehaviour {

    /* An array to store the sprites of our multiplyer */
    public Sprite[] images;

    /* The variable to hold the multiplyerImage on the Main Canvas */
    UnityEngine.UI.Image multiplyerImage;

    /* The variable to store the universal variables script attached to this gameObject */
    UniversalVariables uniVar;


	void Start ()
    {
        uniVar = GameObject.Find("Game Control").GetComponent<UniversalVariables>();
        multiplyerImage = GetComponent<UnityEngine.UI.Image>();	
	}
	
	
	void Update () 
    {
        //Debug.Log(uniVar.multiplyer);

        multiplyerImage.sprite = images[(int)uniVar.multiplyer - 1];

        //GetComponent<Animator>().SetFloat("multiplyer", gameControl.GetComponent<UniversalVariables>().multiplyer);
	}
}
