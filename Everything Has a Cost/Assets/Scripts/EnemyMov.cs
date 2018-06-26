using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private Vector2 mov;
    private bool movRight = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mov = new Vector2(speed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(mov);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //Collider2D otherc = other.collider;

        if (other.collider.CompareTag("Ground"))
        {
            /*Vector3 contactPoint = other.contacts[0].point;
            Vector3 center = otherc.bounds.center;*/
            //Debug.Log(contactPoint);
            //Debug.Log(center);

            if (transform.position.x >= 16 && movRight)
            {
                changeDirection();
                movRight = false;
            }

            if (transform.position.x <= 12 && !movRight)
            {
                changeDirection();
                movRight = true;
            }
            /*if (other.gameObject.transform.position.y > 1)
            {
                changeDirection();
            }*/
        }
    }

    void changeDirection()
    {
        speed *= -1;
    }
}

