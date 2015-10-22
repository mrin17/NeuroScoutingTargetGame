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

    // Use this for initialization
    void Start () {
        //Create a baseball, and set its parent to us
        CreateBaseball();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateBaseball()
    {
        currentBaseball = (GameObject)Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.identity);
        currentBaseball.transform.SetParent(transform);
    }
}
