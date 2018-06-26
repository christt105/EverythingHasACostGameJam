﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public GameObject Target;
    public CameraControl camera;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Target.transform.GetChild(0).transform.position;
            camera.changeEnvironment();
        }
    }
}
