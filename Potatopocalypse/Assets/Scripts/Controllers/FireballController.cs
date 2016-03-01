using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {


    //Vector3 velocity;
    float speed;
    Ray targetRay;
    RaycastHit hitInfo;
    Vector3 targetPosition;
    GameObject gameControl;
    float screenLeft;
    float screenRight;
    bool foundTarget;
    GameObject targetObject;
    Vector2 targetVector;
    float newAngle;
    public GameObject mashedBangerObj;

    public void Initialize(Transform parent, Vector3 target)
    {
        gameControl = GameObject.Find("Game Control");
        foundTarget = false;
        targetObject = null;
        transform.position = parent.position;
        transform.rotation = parent.rotation;

        targetRay = new Ray(transform.position, target);
        targetPosition = targetRay.GetPoint(12.0f);


        transform.localScale = new Vector3(1, 1, 1);                            //Resets the scale so it doesn't keep getting larger and larger ever activation.
        if (gameControl.GetComponent<UniversalVariables>().mashedBanger)
        {
            transform.localScale *= 2;
        }
        else
            transform.localScale = new Vector3(1, 1, 1);

        speed = 2.5f + ((SaveLoad.upgrades.gulletOfSteam.power / 100) * 2.5f);

        Debug.Log("Speed: " + speed);

        gameObject.SetActive(true);
    }
    void Start()
    {
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 7)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 7)).x;
    }
	void Update ()
    {

        if (gameControl.GetComponent<UniversalVariables>().hashseeker)
        {
            if (!foundTarget)
            {
                Collider2D hitColliders = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1f);
                if (hitColliders.GetComponent<Collider2D>().name == "Potato(Clone)")
                {
                    foundTarget = true;
                    targetObject = hitColliders.gameObject;
                }
            }
        }
        if (targetObject != null)
            targetPosition = targetObject.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (foundTarget)
        {
            Vector2 centerTarget = new Vector2(transform.position.x, transform.position.y + 1f);                                                     //Sets center Target to always be straight up in the middle
            targetVector = targetPosition;                                                                                                           //Sets the target to be where the mouse is on the screen     
            newAngle = Mathf.Acos(Vector2.Dot(targetVector, centerTarget) / (targetVector.magnitude * transform.position.magnitude)) * 180 / Mathf.PI;     //Sets the new angle value to be the angle between the center and the new target
            if (centerTarget.x < targetVector.x)                                                                                                     //If the new target is to the right of the center...
                newAngle = -newAngle;                                                                                                                //make the angle negative
            float angle = Mathf.Round(newAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0,0,angle)), 3f);
        }


        if (transform.position == targetPosition || transform.position.x < screenLeft || transform.position.x > screenRight)
        {
            gameControl.GetComponent<UniversalVariables>().multiplyer = 1;
            gameControl.GetComponent<UniversalVariables>().hitStreak = 0;
            Deactivate();
        }
	}

    public void Deactivate()
    {
        transform.position = GameObject.Find("Dino Head").GetComponent<DinoController>().stackPosition;
        targetObject = null;
        foundTarget = false;
        gameObject.SetActive(false);
    }
}
