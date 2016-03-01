using UnityEngine;
using System.Collections;

public class PotatoGenerating : MonoBehaviour {

    float currentTime;
    float previousTime;
    public GameObject potato;
    Vector3 targetLocation;
    float timeVariation;
    public GameObject particleSystem;
    GameObject[] instancesOfPotatos;
    int maxNumberOfPotatos;
    bool hasCreated;
    public Vector3 stackPosition;

	void Start () 
    {
        stackPosition = new Vector3(-999, -999, -999);
        maxNumberOfPotatos = 20;
        instancesOfPotatos = new GameObject[maxNumberOfPotatos];
        for (int i = 0; i < maxNumberOfPotatos; i++)
        {
            instancesOfPotatos[i] = Instantiate(potato) as GameObject;
            instancesOfPotatos[i].SetActive(false);
        }
        currentTime = 0;
        previousTime = currentTime;
        timeVariation = 3;
        hasCreated = false;
	}
	
	void Update () 
    {
        if (Time.timeSinceLevelLoad > 1.5 && !hasCreated)
        {
            Instantiate(particleSystem, new Vector3(0f, -0.4255f, -2f), Quaternion.Euler(new Vector3(270, 0, 0)));
            hasCreated = true;
        }

        targetLocation = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50, Screen.width - 50), Screen.height, 7));
        Create();
	}
    void Create()
    {
        currentTime = Time.timeSinceLevelLoad;
        if (currentTime > previousTime + timeVariation)
        {
            previousTime = currentTime;
            GameObject instance = GetNextAvailibleInstance();
            if (instance != null)
                instance.GetComponent<PotatoController>().Initialize(targetLocation);
            timeVariation -= 0.025f;

            if (timeVariation < 1)
            {
                timeVariation = 1;
            }
        }
    }
    GameObject GetNextAvailibleInstance()
    {
        for (int i = 0; i < maxNumberOfPotatos; i++)
        {
            if (!instancesOfPotatos[i].activeSelf) return instancesOfPotatos[i];
        }
        return null;
    }
}
