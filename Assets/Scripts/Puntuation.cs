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
        if (GameManager.Instance.isDead)
        {
            DeadOrNot.text = "Survived: Yes";
        }
        else
        {
            DeadOrNot.text = "Survived: No";
        }

        PeopleSaved.text = "People Saved: " + GameManager.Instance.peopleRescued + "/" +GameManager.Instance.totalPeople;

        if(GameManager.Instance.hasBarbie ) 
        {
            Barbie.text = "Barbie: Yes";
        }
        else
        {
            Barbie.text = "Barbie: No";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
