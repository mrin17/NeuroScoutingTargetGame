using UnityEngine;
using System.Collections;

//Basically tracks the whole game
//controlls timing, which baseballs to throw, public tweakable vars, and score
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
    int numCorrectBaseballs = 0;
    int numIncorrectBaseballs = 0;
    float score = 0;

    public float correctPoints = 8;
    public float incorrectPoints = -1;

    int trialsSoFar = 0;
    scrTrialNum sTrialNum;

    // Use this for initialization
    void Start () {
        sTrialNum = FindObjectOfType<scrTrialNum>();
        RestartGame();
    }

    //convenient for when i need to do multiple trials
    void RestartGame()
    {
        //I'm adding one here so there's the chance the baseball won't appear
        positionForTargetBall = Random.Range(0, numberOfBaseballs + 1);
        //randomize target rotation
        targetRotation = ((int)(Random.Range(0, 360) / rotationInterval)) * rotationInterval;

        //wait for initial display to be finished (same time as any other baseball)
        baseballThrowTimer = 0;
        thrownBaseballs = 0;

        //create the initial display
        Instantiate(Resources.Load("preText"));
        Instantiate(Resources.Load("preInitialBaseball"), Vector3.zero, Quaternion.Euler(new Vector3(0, 0, targetRotation)));
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
                //if you hit the right baseball, you gain score.
                //if you hit the wrong baseball, you lose score.
                scoreBaseball(1);
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
            else if (sTrialNum.numTrials != trialsSoFar)
            {
                //end game
                trialsSoFar++;
                //if we did the required number of trials, end the game
                if (sTrialNum.numTrials == trialsSoFar)
                {
                    maxScore = (numCorrectBaseballs * correctPoints) + (numIncorrectBaseballs * incorrectPoints * -1);
                    score = ((int) (score * 10)) / 10; //round score to one decimal place
                    Instantiate(Resources.Load("preScoreDisplay"));
                    //go through all the baseballs and re-enable them by displaying their data
                    foreach (Transform t in transform)
                    {
                        t.gameObject.GetComponent<scrBaseball>().displayData();
                    }
                }
                //otherwise, we go again
                else
                {
                    RestartGame();
                }
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
        numCorrectBaseballs++;
    }

    //creates a baseball with a different rotation than the target
    void CreateNonTargetBaseball()
    {
        int rot = getRandomNonTargetRotation();
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.Euler(new Vector3(0, 0, rot)));
        currentBaseball.transform.SetParent(transform);
        numIncorrectBaseballs++;
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

    //used for when the baseball destroys itself, it calls this so we can score it
    public void addDestroyScore()
    {
        if (!pressedSpace)
            scoreBaseball(-1);
    }

    //The faster you see the target (the lower baseballThrowTimer is), the more points you get
    //if you hit the right baseball, you gain score.
    //if you hit the wrong baseball, you lose score.
    //if you do not hit the correct baseball, you lose score.
    //if you do not hit the wrong baseball, you gain score.
    void scoreBaseball(int multiplier)
    {
        bool correct = false;
        if ((int) currentBaseball.transform.localRotation.eulerAngles.z == targetRotation)
        {
            score += (appearTimeMax - baseballThrowTimer) / appearTimeMax * correctPoints * multiplier;
            if (multiplier >= 0)
            {
                Instantiate(Resources.Load("preCheck"), currentBaseball.transform.position, Quaternion.identity);
                correct = true;
            }
            else
            {
                Instantiate(Resources.Load("preX"), currentBaseball.transform.position, Quaternion.identity);
                correct = false;
            }
        }
        else
        {
            score += (appearTimeMax - baseballThrowTimer) / appearTimeMax * incorrectPoints * multiplier;
            if (multiplier <= 0)
            {
                Instantiate(Resources.Load("preCheck"), currentBaseball.transform.position, Quaternion.identity);
                correct = true;
            }
            else
            {
                Instantiate(Resources.Load("preX"), currentBaseball.transform.position, Quaternion.identity);
                correct = false;
            }
        }
        currentBaseball.GetComponent<scrBaseball>().saveTransform(correct);
    }

    //accessors
    public float getScore()
    {
        return score;
    }

    public float getMaxScore()
    {
        return maxScore;
    }

}
