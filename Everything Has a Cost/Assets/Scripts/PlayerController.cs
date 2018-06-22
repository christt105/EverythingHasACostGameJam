using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    private Vector2 mov;
    public float speed;

    private bool jump;
    public float jumpPower = 6.5f;
    private bool grounded;

    private int money;

    private void Awake()
    {
        money = 5;
    }

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float h;
        float v = 0;
        h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");



        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;

        if (jump)
        {
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        mov.Set(h, v);

    }

    void FixedUpdate()
    {
        transform.Translate(mov * speed * Time.deltaTime);
    }

    public void setCoin(int c)
    {
        money += c;
    }
}
