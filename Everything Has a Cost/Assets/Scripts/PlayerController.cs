using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    private Vector2 mov;
    public float speed;

    private bool jump;
    public float jumpPower = 6.5f;
    public bool grounded;

    public Text stepsText;
    private Vector3 offsetstepstext;
    public Text moneyText;
    private int money;
    private int steps;

    private void Awake()
    {
        money = 5;
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
                
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
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
        updateStepsText(); //Updates value distance player-home and position up player
    }

    void LateUpdate()
    {
       
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
