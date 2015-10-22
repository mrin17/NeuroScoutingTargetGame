using UnityEngine;
using System.Collections;

public class scrBaseballController : MonoBehaviour {

    public Vector3 startPos = new Vector3(-.7f, -.7f, 0);

    public float minScale = 0f;
    public float maxScale = 2f;

    public float appearTimeMax = 2f;

    public float maxHSpeed = 1.5f;
    public float maxVSpeed = 1f;

    GameObject currentBaseball;

    public int targetRotation = 0;
    public int rotationInterval = 45;

    // Use this for initialization
    void Start () {
        //Create a baseball, and set its parent to us
        CreateTargetBaseball();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateTargetBaseball()
    {
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.Euler(new Vector3(0, 0, targetRotation)));
        currentBaseball.transform.SetParent(transform);
    }

    void CreateNonTargetBaseball()
    {
        int rot = getRandomNonTargetRotation();
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.Euler(new Vector3(0, 0, rot)));
        currentBaseball.transform.SetParent(transform);
    }

    int getRandomNonTargetRotation()
    {
        int rot = ((int)(Random.Range(0, 360) / rotationInterval)) * rotationInterval;
        if (rot == targetRotation)
            rot = (rot + rotationInterval) % 360;
        return rot;
    }
}
