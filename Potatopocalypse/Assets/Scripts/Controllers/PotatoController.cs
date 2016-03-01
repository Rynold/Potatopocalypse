using UnityEngine;
using System.Collections;

public class PotatoController : MonoBehaviour {

    float hSpeed;
    float vSpeed;
    float screenLeft;
    float screenRight;
    public GameObject fry;
    Vector3 velocity;
    public GameObject explosion;
    public GameObject midAirExplosion;
    public GameObject mashedBangerObj;
    UniversalVariables uniVar;

    public void Initialize(Vector3 parent)
    {
        transform.position = parent;
        hSpeed = Random.Range(-0.015f, 0.015f);
        gameObject.SetActive(true);
    }

    void Start () 
    {
        uniVar = GameObject.Find("Game Control").GetComponent<UniversalVariables>();
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Screen.width + 10, 0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 10, 0,0)).x;
        vSpeed = -0.015f;
        transform.localScale = new Vector3(1.5f,1.5f,1);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Ground")
        {
            uniVar.lives -= 1;
            Instantiate(explosion, new Vector3(transform.position.x,transform.position.y,-5), Quaternion.Euler(0, 0, 0));
            transform.position = GameObject.Find("Game Control").GetComponent<PotatoGenerating>().stackPosition;
            uniVar.multiplyer = 1;
            gameObject.SetActive(false);
        }
        if (collisionInfo.collider.name == "Fireball(Clone)")
        {
            for (float i = 0; i < (6f + SaveLoad.upgrades.jawStretching.power) * uniVar.multiplyer; i++)
            {
                Instantiate(fry, transform.position, Quaternion.Euler(0, 0, 0));
            }

            if(uniVar.multiplyer != 5)
                uniVar.multiplyer++;

            uniVar.hitStreak++;

            if (uniVar.mashedBanger == true)
                Instantiate(mashedBangerObj, collisionInfo.transform.position, Quaternion.identity);
            collisionInfo.gameObject.GetComponent<FireballController>().Deactivate();
            Instantiate(midAirExplosion, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.Euler(0, 0, 0));
            transform.position = GameObject.Find("Game Control").GetComponent<PotatoGenerating>().stackPosition;
            gameObject.SetActive(false);


        }
        if (collisionInfo.collider.name == "MashedBangerObject(Clone)")
        {
            for (float i = 0; i < 6f * uniVar.multiplyer; i++)
            {
                Instantiate(fry, collisionInfo.transform.position, Quaternion.Euler(0, 0, 0));
            }
            gameObject.transform.position = GameObject.Find("Game Control").GetComponent<PotatoGenerating>().stackPosition;
            gameObject.SetActive(false);
        }
    }
	
	void Update () 
    {
        //Changes its direction when it hits the sides of the screen
        if (transform.position.x < screenLeft || transform.position.x > screenRight)
        {
            hSpeed = -hSpeed;
        }

        velocity = new Vector3(transform.position.x + hSpeed, transform.position.y + vSpeed, -3);
        transform.position = Vector3.MoveTowards(transform.position,velocity,2f*Time.deltaTime);
	}
}
