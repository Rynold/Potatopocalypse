using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {

    public Sprite[] HeadImages;
    SpriteRenderer spriteRenderer;
    public bool isAlive;
    Event e;
    public Vector3 targetVector;
    Vector3 mousePosition;
    public GameObject fireBallPreFab;
    public GameObject[] instances;
    int maximumFirballCount;
    Vector3 centerTarget;
    float newAngle;
    public bool isRotating;
    float targetAngle;
    public GameObject targetObj;
    public Vector3 targetObjLocation;
    GameObject gameControl;
    float coolDown;
    Quaternion targetRotation;
    float rotatinSpeed;
    public Vector3 stackPosition = new Vector3(-999, -999, -999);
    UniversalVariables uniVar;
    public GameObject fire;
    bool hasCreatedFire;
    //Collider2D pauseCollider;


	void Start () 
    {
        isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        maximumFirballCount = 30;
        instances = new GameObject[maximumFirballCount];
        for (int i = 0; i < maximumFirballCount; i++)
        {
            instances[i] = Instantiate(fireBallPreFab) as GameObject;
            instances[i].SetActive(false);
        }
        isRotating = false;
        newAngle = 0f;
        
        

        gameControl = GameObject.Find("Game Control");
        uniVar = gameControl.GetComponent<UniversalVariables>();
        hasCreatedFire = false;
        //pauseCollider = GameObject.Find("Pause Background").GetComponent<Collider2D>();

        rotatinSpeed = 75f + ((uniVar.necksersizePower / 100) * 75);
        Debug.Log("Rotating Speed: " + rotatinSpeed);
	}


    void OnGUI()
    {
        e = Event.current;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(e.mousePosition.x,Screen.height - e.mousePosition.y,7));
    }


	void Update () 
    {
        if (isAlive)    //If the player is still alive.
        {
            spriteRenderer.sprite = HeadImages[0];
            if (Input.GetMouseButtonDown(0))               //If the mouse was pressed.
            {
                if (!uniVar.paused)// && !pauseCollider.OverlapPoint(mousePosition))
                {
                    centerTarget = new Vector2(0.0f, 7.3f);                                                                                                  //Sets center Target to always be straight up in the middle
                    targetVector = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(transform.position.x, transform.position.y);                  //Sets the target to be where the mouse is on the screen     
                    newAngle = Mathf.Acos(Vector2.Dot(targetVector, centerTarget) / (targetVector.magnitude * centerTarget.magnitude)) * 180 / Mathf.PI;     //Sets the new angle value to be the angle between the center and the new target
                    if (centerTarget.x < targetVector.x)                                                                                                     //If the new target is to the right of the center...
                        newAngle = -newAngle;                                                                                                                //make the angle negative
                    targetAngle = Mathf.Round(newAngle);                                                                                                     //Rounds the new angle to the nearest unit.
                    targetRotation.eulerAngles = new Vector3(0, 0, targetAngle);                                                                             //Sets the Target quaternion's euler to a vector with X and Y at 0 and Z at the new angle.
                    targetObjLocation = Camera.main.ScreenToWorldPoint(new Vector3(e.mousePosition.x, Screen.height - e.mousePosition.y, 7));                //Sets the target objects location to be where the mouse is.
                    isRotating = true;                                                                                                                       //Sets isRotating to true to tell the rest of the code its rotating
                    Instantiate(targetObj, targetObjLocation, Quaternion.Euler(new Vector3(0, 0, 0)));                                                       //Instantiates the target object.
                }
            }
            if (isRotating == true) //If the object is rotating
            {
                if (transform.rotation != targetRotation)          //If it hasn't rotated all the way to where its supposed to yet
                {
                    float step = rotatinSpeed * Time.deltaTime;                                                  //Set a step float to the rotating speed * Time.deltaTime
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);     //Rotate gradually towards the new angle
                }
                else                                              //If it has rotated all the way to where its supposed to
                {
                    if (coolDown <= 0)
                        Fire();                                   //call the fire function
                    isRotating = false;                           //Tell the system its not rotating anymore
                }

            }
            if (coolDown > 0)
            {
                coolDown--;                                      //If its still on coolDown, decrement it by 1 per frame
            }
        }
        else if (!isAlive && !hasCreatedFire)
        {
            spriteRenderer.sprite = HeadImages[1];
            hasCreatedFire = true;
            Instantiate(fire, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.Euler(0, 0, 0));
        }
	}

    void Fire()
    {

        if (uniVar.crippleChip)                                      //***If the cripple chip PowerUp is on***
        {
            float rotatingDifference = -5f;                                                                  //***Set an initial size for the difference in rotation***
            for (int i = 0; i < 3; i++)                                                                      //***Loop 3 times to create 3 fireballs***
            {
                float r = Mathf.Sqrt(Mathf.Pow(targetVector.x, 2) + Mathf.Pow(targetVector.y, 2));           //***Convert the targetVector into polar format to 
                float ang = Mathf.Rad2Deg * Mathf.Atan2(targetVector.y, targetVector.x);                     //manipulate the angle easier***
                ang += rotatingDifference;
                ang = Mathf.Deg2Rad * ang;                                                                   //***Add the rotating difference to the angle***
                targetVector.x = r * (Mathf.Rad2Deg * (Mathf.Cos(ang)));                                     //***Convert the polar co-ordinates back to cartesian***
                targetVector.y = r * (Mathf.Rad2Deg*(Mathf.Sin(ang)));

                GameObject instance = GetNextAvailibleInstance();
                if (instance != null)
                    instance.GetComponent<FireballController>().Initialize(transform, targetVector);         //***Initaialize a fireBall***

                if (i == 0)
                    rotatingDifference += 10f;                                                               //***Change the difference in rotation***
                else
                    rotatingDifference += 1f;

            }
            coolDown = 30;
        }
        else
        {
        GameObject instance = GetNextAvailibleInstance();
        if (instance != null)
            instance.GetComponent<FireballController>().Initialize(transform,targetVector);
        coolDown = 30;
        }
    }

    GameObject GetNextAvailibleInstance()
    {
        for(int i = 0; i < maximumFirballCount; i++)
        {
            if (!instances[i].activeSelf) 
                return instances[i];
        }
        return null;
    }

    bool isWithinBounds(GameObject obj)
    {
        Debug.Log("Mouse position: ("+e.mousePosition.x+","+e.mousePosition.y+")");
        if (e.mousePosition.x > obj.GetComponent<GUITexture>().pixelInset.x
            && e.mousePosition.x < Screen.width
            && e.mousePosition.y < 50)
            return true;
        else
            return false;
    }
}
