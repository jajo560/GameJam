using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuation : MonoBehaviour
{

    public TextMeshProUGUI DeadOrNot;
    public TextMeshProUGUI PeopleSaved;
    public TextMeshProUGUI Barbie;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.IsSafe)
        {
            DeadOrNot.text = "Dead: No";
        }
        else
        {
            DeadOrNot.text = "Dead: Yes";
        }

        PeopleSaved.text = "People Saved: " + GameManager.Instance.peopleRescued + "/" +GameManager.Instance.totalPeople;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
