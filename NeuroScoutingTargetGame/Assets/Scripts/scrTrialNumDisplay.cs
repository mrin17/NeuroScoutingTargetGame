using UnityEngine;
using System.Collections;

//Displays the number of trials on the intro scene
public class scrTrialNumDisplay : MonoBehaviour {

    scrTrialNum stn;
    TextMesh tm;

	// Use this for initialization
	void Start () {
        stn = FindObjectOfType<scrTrialNum>();
        tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = "< " + stn.numTrials + " >";
	}
}
