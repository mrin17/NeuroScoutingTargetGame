using UnityEngine;
using System.Collections;

//Mike - script to be put on the baseball. Controls movement and scale
public class scrBaseball : MonoBehaviour {

    public float minScale = 0f;
    public float maxScale = 1f;

    public float appearTimeMax = 2f;

    public float maxHSpeed = 20f;
    public float maxVSpeed = 10f;

    Rigidbody2D rb;
    
    float appearTimer = 0f;

    scrBaseballController baseballController;


    // Use this for initialization
    void Start () {
        baseballController = transform.GetComponentInParent<scrBaseballController>();
        rb = GetComponent<Rigidbody2D>();

        //add a randomized force to the baseball to give a pitch variance
        rb.AddForce(new Vector3(Random.Range(-maxHSpeed, maxHSpeed), Random.Range(-maxVSpeed, maxVSpeed)));
	}
	
	// Update is called once per frame
	void Update () {
        //as time goes by, increase the size of the baseball
        float scaleRatio = (appearTimer / appearTimeMax * (maxScale - minScale)) + minScale;
        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);

        //only have the baseball appear for appearTiemMax seconds, then destroy the baseball
        appearTimer += Time.deltaTime;
        if (appearTimer > appearTimeMax)
            Destroy(gameObject);
	}

}
