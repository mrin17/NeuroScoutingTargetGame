﻿using UnityEngine;
using System.Collections;

//for the checks and xs displayed when a baseball is scored
public class scrCheckX : MonoBehaviour {

    public bool destroyOnTimer = true;
    protected float timerMax = .5f;
    float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > timerMax && destroyOnTimer)
            Destroy(gameObject);
	}
}
