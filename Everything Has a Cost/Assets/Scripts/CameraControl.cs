using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Vector3 offset;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mov = offset + player.transform.position;
        mov[1] = 0.05f;

        if (mov.x >= 3.08f)
            transform.position = mov;

	}
}
