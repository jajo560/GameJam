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
    public GameObject Player;
    public Animator anim;
    private SpriteRenderer spriteRender;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRender = Player.GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        ApplyDebuff();

        
    }

    private void FixedUpdate()
    {
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
                speedDebuff = 0.9f;
                break;
            case 2:
                speedDebuff = 0.8f;
                break;
            case 3:
                speedDebuff = 0.7f;
                break;
            default:
                break;
        }
    }

    private void Move()
    {
        if (horizontal < 0)
        {
            anim.SetTrigger("Running");
            spriteRender.flipX = true;
            transform.position += new Vector3(horizontal, 0, 0) * speed * speedDebuff * Time.deltaTime;
        }

        else if (horizontal > 0)
        {
            anim.SetTrigger("Running");
            spriteRender.flipX = false;
            transform.position += new Vector3(horizontal, 0, 0) * speed * speedDebuff * Time.deltaTime;
        }

        else if (vertical > 0)
        {
            anim.SetTrigger("Behind");
            transform.position += new Vector3(0, vertical, 0) * speed  * speedDebuff* Time.deltaTime;
        }


        else if (vertical < 0)
        {
            anim.SetTrigger("Front");
            transform.position += new Vector3(0, vertical, 0) * speed  * speedDebuff* Time.deltaTime;
        }

        else
        {
            anim.SetTrigger("Stand");
        }

    }

    private void HandleInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Persona")
        {
            if (GameManager.Instance.Weight + collision.GetComponent<IRescue>().weight <= GameManager.Instance.MaxWeight)
            {
                collision.gameObject.SetActive(false);
                GameManager.Instance.PeopleInSack++;
                collision.GetComponent<IRescue>().Rescue();
            }
            
        }

        if(collision.tag == "Bunker")
        {
            GameManager.Instance.SavePeople();
            GameManager.Instance.PeopleInSack = 0;
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
