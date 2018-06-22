using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    private Vector2 mov;
    public float speed;

    private bool jump;
    private bool grounded;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float h;
        float v = 0;
        h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxis("Vertical");

        //rb2D.IsTouching()

        if (Input.GetButton("Jump"))
            v = 2;
        if (v != 0)
            print(v);

        mov.Set(h, v);

    }

    void FixedUpdate()
    {
        transform.Translate(mov * speed * Time.deltaTime);
    }
}
