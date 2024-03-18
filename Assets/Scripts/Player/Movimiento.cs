using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    public float horizontal;
    public float vertical;
    public float speedDebuff;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        ApplyDebuff();

        Move();



    }

    private void ApplyDebuff()
    {
        switch (GameManager.Instance.Weight)
        {
            case 0:
                speedDebuff = 1;
                break;
            case 1:
                speedDebuff = 0.8f;
                break;
            case 2:
                speedDebuff = 0.6f;
                break;
            case 3:
                speedDebuff = 0.4f;
                break;
            default:
                break;
        }
    }

    private void Move()
    {
        if (horizontal < 0)
        {
            transform.position += new Vector3(horizontal, 0, 0) * speed * speedDebuff * Time.deltaTime;
        }

        if (horizontal > 0)
        {
            transform.position += new Vector3(horizontal, 0, 0) * speed * speedDebuff * Time.deltaTime;
        }

        if (vertical > 0)
        {
            transform.position += new Vector3(0, vertical, 0) * speed  * speedDebuff* Time.deltaTime;
        }


        if (vertical < 0)
        {
            transform.position += new Vector3(0, vertical, 0) * speed  * speedDebuff* Time.deltaTime;
        }
    }

    private void HandleInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Persona")
        {
            if (GameManager.Instance.Weight + collision.GetComponent<IRescue>().weight <= GameManager.Instance.MaxWeight)
            {
                collision.gameObject.SetActive(false);
                collision.GetComponent<IRescue>().Rescue();
            }
            
        }

        if(collision.tag == "Bunker")
        {
            GameManager.Instance.Weight = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Bunker")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameManager.Instance.IsSafe = true;
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bunker")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.Instance.IsSafe = false;
        }
    }
}
