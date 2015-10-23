using UnityEngine;
using System.Collections;

public class scrBaseballController : MonoBehaviour {

    public Vector3 startPos = new Vector3(-.7f, -.7f, 0);

    public float minScale = 0f;
    public float maxScale = 2f;

    public float appearTimeMax = 2f;
    public float waitTimeMax = 1f;
    float baseballThrowTimer = 0;

    public float maxHSpeed = 1.5f;
    public float maxVSpeed = 1f;

    GameObject currentBaseball;

    int targetRotation = 0;
    public int rotationInterval = 45;

    public int numberOfBaseballs = 6;
    int thrownBaseballs = 0;
    int positionForTargetBall = 0;
    bool pressedSpace = false;

    float maxScore = 0;
    float score = 0;

    public float correctPoints = 4;
    public float incorrectPoints = -1;

    // Use this for initialization
    void Start () {
        //I'm adding one here so there's the chance the baseball won't appear
        positionForTargetBall = Random.Range(0, numberOfBaseballs + 1);
        //randomize target rotation
        targetRotation = ((int)(Random.Range(0, 360) / rotationInterval)) * rotationInterval;
        //set up max score
        maxScore = correctPoints;
        baseballThrowTimer = appearTimeMax + waitTimeMax;
	}
	
	// Update is called once per frame
	void Update () {
        //if you press space, we edit your score accordingly
        //you can only press space once per baseball
        if (Input.GetKeyDown(KeyCode.Space) && !pressedSpace)
        { 
            if (currentBaseball)
            {
                pressedSpace = true;
                //if you hit the right baseball, you gain score. Otherwise, you lose score
                //The faster you see the target (the lower baseballThrowTimer is), the more points you get
                if (currentBaseball.transform.rotation.z == targetRotation)
                {
                    score += (appearTimeMax - baseballThrowTimer) / appearTimeMax * correctPoints;
                }
                else
                {
                    score += (appearTimeMax - baseballThrowTimer) / appearTimeMax * incorrectPoints;
                }
            }


        }

        //use baseballThrowTimer as a timer. If it gets set to 0, then we throw another baseball   
        if (baseballThrowTimer >= appearTimeMax + waitTimeMax)
        {
            //until we hit 6 baseballs
            if (thrownBaseballs < numberOfBaseballs)
            {
                //we already know where the target is going to be, so choose target or non-target
                if (thrownBaseballs == positionForTargetBall)
                    CreateTargetBaseball();
                else
                    CreateNonTargetBaseball();
                thrownBaseballs++;
                pressedSpace = false;
            }
            else
            {
                //end game
            }
            baseballThrowTimer = 0;
        }
        else
        {
            baseballThrowTimer += Time.deltaTime;
        }
	}

    //creates a baseball with the target rotation
    void CreateTargetBaseball()
    {
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.Euler(new Vector3(0, 0, targetRotation)));
        currentBaseball.transform.SetParent(transform);
    }

    //creates a baseball with a different rotation than the target
    void CreateNonTargetBaseball()
    {
        int rot = getRandomNonTargetRotation();
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.Euler(new Vector3(0, 0, rot)));
        currentBaseball.transform.SetParent(transform);
    }

    //picks a random rotation that is a multiple of rotationInterval that is not the target
    //enforced by, for now, incrementing the interval if we do see the target randomly
    int getRandomNonTargetRotation()
    {
        int rot = ((int)(Random.Range(0, 360) / rotationInterval)) * rotationInterval;
        if (rot == targetRotation)
            rot = (rot + rotationInterval) % 360;
        return rot;
    }

}
