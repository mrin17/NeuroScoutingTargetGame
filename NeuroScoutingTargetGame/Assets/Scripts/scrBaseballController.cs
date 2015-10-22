using UnityEngine;
using System.Collections;

public class scrBaseballController : MonoBehaviour {

    public Vector3 startPos = new Vector3(-.7f, -.7f, 0);

    GameObject currentBaseball;

    // Use this for initialization
    void Start () {
        //Create a baseball, and set its parent to us
        currentBaseball = (GameObject) Instantiate(Resources.Load("preBaseball"), startPos, Quaternion.identity);
        currentBaseball.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
