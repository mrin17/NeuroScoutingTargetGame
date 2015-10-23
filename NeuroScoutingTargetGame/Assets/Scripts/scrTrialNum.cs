using UnityEngine;
using System.Collections;

//tracks the trial number, this object stays throughout the whole game
public class scrTrialNum : MonoBehaviour {

    public int numTrials = 1;
    public int maxTrials = 10;
    public int minTrials = 1;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        //press left and right to increment and decrement trials, space to continue
	    if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Application.loadedLevelName == "scnIntro")
            {
                if (numTrials < maxTrials)
                    numTrials++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Application.loadedLevelName == "scnIntro")
            {
                if (numTrials > minTrials)
                    numTrials--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Application.loadedLevelName == "scnIntro")
            {
                Application.LoadLevel("scnBaseballDiamond");
            }
        }
    }
}
