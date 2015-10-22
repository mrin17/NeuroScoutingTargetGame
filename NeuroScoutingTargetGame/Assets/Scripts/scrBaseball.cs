using UnityEngine;
using System.Collections;

//Mike - script to be put on the baseball. Controls movement and scale
public class scrBaseball : MonoBehaviour {

    public float appearTimeMax = 2f;
    float appearTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        appearTimer += Time.deltaTime;
        if (appearTimer > appearTimeMax)
            Destroy(gameObject);
	}

}
