﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Vector3 offset;
    private Camera cam;
    public PlayerController player;
    private bool outside;

    public CoinCheck coin;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        outside = true;
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 mov = offset + player.transform.position;
        mov[1] = 0.05f;

        if (outside)
        {
            if (mov.x >= 3.08f)
                transform.position = mov;
        }          
	}

    public void changeEnvironment()
    {
        if (outside)
        {
            outside = false;
            transform.position = new Vector3(-6.93f, 0.5f, -10);
        }
        else
        {
            outside = true;
            //Reactive coins
            coin.reactive();
            transform.position = new Vector3(3.08f, 0.05f, -10);
        }
    }
}
