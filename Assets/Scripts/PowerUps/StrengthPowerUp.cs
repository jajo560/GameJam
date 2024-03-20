using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPowerUp : MonoBehaviour
{
    public float PowerUpTime;

    public Movimiento player;

    public float OriginalSpeed;

    // Update is called once per frame

    private void Start()
    {
        player = FindObjectOfType<Movimiento>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(ApplyPowerUp());
        }
    }

    IEnumerator ApplyPowerUp()
    {
        GameManager.Instance.strengthBuff = true;
        yield return new WaitForSeconds(PowerUpTime);
        GameManager.Instance.strengthBuff = false;
        gameObject.SetActive(false);
    }
}
