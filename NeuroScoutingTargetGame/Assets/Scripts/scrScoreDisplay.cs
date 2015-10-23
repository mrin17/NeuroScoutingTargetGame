using UnityEngine;
using System.Collections;

public class scrScoreDisplay : MonoBehaviour {

    float maxScore = 0;
    float score = 0;

	// Use this for initialization
    //get the score from scrBaseballController, and display max score vs your score
	void Start () {
        scrBaseballController sbc = FindObjectOfType<scrBaseballController>();
        score = sbc.getScore();
        maxScore = sbc.getMaxScore();
        GetComponent<TextMesh>().text = "Max Score: " + maxScore + System.Environment.NewLine + "Your Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
