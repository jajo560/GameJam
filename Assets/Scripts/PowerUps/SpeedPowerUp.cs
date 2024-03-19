using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float PowerUpTime;

    public Movimiento player;

    public float OriginalSpeed;

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movimiento>() != null) 
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(ApplyPowerUp());
            
        }
    }

    IEnumerator ApplyPowerUp() 
    {
        OriginalSpeed = player.speed;
        player.speed = OriginalSpeed * 1.5f;
        yield return new WaitForSeconds(PowerUpTime);
        player.speed = OriginalSpeed;
        gameObject.SetActive(false);
    }
}
