using UnityEngine;
using System.Collections;

//Mike - script to be put on the baseball. Controls movement and scale
public class scrBaseball : MonoBehaviour {

    public float minScale = .1f;
    public float maxScale = 1f;
    public float appearTimeMax = 2f;
    float appearTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //as time goes by, increase the size of the baseball
        float scaleRatio = appearTimer / appearTimeMax * (maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);

        //only have the baseball appear for appearTiemMax seconds, then destroy the baseball
        appearTimer += Time.deltaTime;
        if (appearTimer > appearTimeMax)
            Destroy(gameObject);
	}

}
