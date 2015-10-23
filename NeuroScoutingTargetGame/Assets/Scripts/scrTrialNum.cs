﻿using UnityEngine;
using System.Collections;

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
            Application.LoadLevel("scnBaseballDiamond");
        }
    }
}
