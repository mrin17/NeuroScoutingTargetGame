using UnityEngine;
using System.Collections;

//Mike - script to be put on the baseball. Controls movement and scale
public class scrBaseball : MonoBehaviour {

    float minScale = 0f;
    float maxScale = 0f;

    float appearTimeMax = 0f;

    float maxHSpeed = 0f;
    float maxVSpeed = 0f;

    Rigidbody2D rb;
    
    float appearTimer = 0f;

    Vector3 savedPos = Vector3.zero;
    Quaternion savedRot = Quaternion.identity;
    bool correct = false;

    scrBaseballController baseballController;


    // Use this for initialization
    void Start () {
        baseballController = transform.GetComponentInParent<scrBaseballController>();
        rb = GetComponent<Rigidbody2D>();

        //grab the values from the parent
        minScale = baseballController.minScale;
        maxScale = baseballController.maxScale;
        appearTimeMax = baseballController.appearTimeMax;
        maxHSpeed = baseballController.maxHSpeed;
        maxVSpeed = baseballController.maxVSpeed;

        //add a randomized force to the baseball to give a pitch variance
        rb.AddForce(new Vector3(Random.Range(-maxHSpeed, maxHSpeed), 
                                Random.Range(-maxVSpeed, maxVSpeed)));
	}
	
	// Update is called once per frame
	void Update () {
        //as time goes by, increase the size of the baseball
        float scaleRatio = (appearTimer / appearTimeMax * (maxScale - minScale)) + minScale;
        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);

        //only have the baseball appear for appearTiemMax seconds, then disable the baseball
        appearTimer += Time.deltaTime;
        if (appearTimer > appearTimeMax) {
            //if you do not hit the correct baseball, you lose score.
            //if you do not hit the wrong baseball, you gain score.
            baseballController.addDestroyScore();
            this.gameObject.SetActive(false);
        }
	}

    public void saveTransform(bool c)
    {
        savedPos = transform.position;
        savedRot = transform.rotation;
        correct = c;
    }

}
