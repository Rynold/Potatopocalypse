using UnityEngine;
using System.Collections;

public class PotatoParticleControl : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        if (Time.timeSinceLevelLoad > 1)
            GetComponent<ParticleSystem>().enableEmission = true;
	}
}
