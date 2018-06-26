using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    private Vector2 mov;
    public float speed;

    public CameraControl cam;

    public float jumpPower = 6.5f;
    public bool grounded;

    public Text stepsText;
    private Vector3 offsetstepstext;
    public Text moneyText;
    public Text stepsToHome;
    private int money;
    private int steps;

    private void Awake()
    {
        money = 1;
    }

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        setMoneyText();
        
        offsetstepstext = transform.position - stepsText.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float h;
        float v = 0;
        h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
               
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        mov.Set(h, v);
                
    }

    void FixedUpdate()
    {
        transform.Translate(mov * speed * Time.deltaTime);
        updateStepsText(); //Updates value distance player-home and position up player
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector2(-8, -1.46f);
            money /= 2;
            cam.changeEnvironment();
        }
        
    }

    public void setCoin(int c)
    {
        money += c;
    }

    public void setMoneyText()
    {
        moneyText.text = "Money: " + money.ToString();
    }

    void updateStepsText()
    {
        stepsText.transform.position = transform.position - offsetstepstext;
        updateSteps();
        stepsText.text = "Steps: " + steps.ToString();
    }

    void updateSteps()
    {
        steps = (int)transform.position.x;
    }
}
