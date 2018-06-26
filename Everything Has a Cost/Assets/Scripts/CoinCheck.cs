using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheck : MonoBehaviour {

    public PlayerController playerS;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS.setCoin(1);
            playerS.setMoneyText();
            gameObject.SetActive(false);
        }

    }

    public void reactive()
    {
        gameObject.SetActive(true);          
    }
}
