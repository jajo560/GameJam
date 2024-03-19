using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbie : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento>() != null)
        {
            GameManager.Instance.hasBarbie = true;
            gameObject.SetActive(false);

        }

    }

}
