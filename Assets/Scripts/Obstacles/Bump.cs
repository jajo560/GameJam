using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bump : MonoBehaviour
{

    public float stunDuration;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D Player = other.GetComponent<Rigidbody2D>();  
            StartCoroutine(Stun(Player));

        }

    }

    private IEnumerator Stun(Rigidbody2D Player)
    {
        float currentSpeed = Player.GetComponent<Movimiento>().speed;
        Player.GetComponent<Movimiento>().speed = 0;
        yield return new WaitForSeconds(stunDuration);
        Player.GetComponent<Movimiento>().speed = currentSpeed;

    }

}
