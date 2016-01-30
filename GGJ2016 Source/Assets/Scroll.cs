﻿using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 offest = new Vector2(Time.time * speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offest;
	}
}
