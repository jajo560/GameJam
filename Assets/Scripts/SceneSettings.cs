using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneSettings : MonoBehaviour
{
    [Header("Timer")]
    public float MaxTime;
    public float Timer;
    private bool _canCalculatePoints = true;
    

    [Header("Point Settings")]
    public int TotalPeople;
    public int PeopleRescued;
    public int TotalPoints;
    private float _rescuePercentage;

    [Header("UI")]
    public TextMeshProUGUI SavedText;
    public TextMeshProUGUI TimerText;
    public List<Image> images;

    // Start is called before the first frame update
    void Start()
    {
        Timer = MaxTime;
        PeopleRescued = 0;

        foreach(GameObject go in FindObjectsOfType<GameObject>())
        {
            if(go.GetComponent<IRescue>() != null) 
            { 
                TotalPeople++;
            }
        }

        foreach(var im in images) 
        {
            var tempColor = im.color;
            tempColor.a = .5f;
            im.color = tempColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SavedText.text = PeopleRescued + " / " + TotalPeople;

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            TimerText.text = Timer.ToString("00:00");
        }
        else if(Timer <= 0) 
        {
            if (_canCalculatePoints)
            {
                CalculateRescuePercentage();

                if (GameManager.Instance.IsSafe)
                {
                    TotalPoints += 3;
                }
                else
                {
                    TotalPoints += 0;
                }

                Debug.Log(TotalPoints);

                _canCalculatePoints = false;
            }
            

            Time.timeScale = 0f;

            
        }
    }

    private void CalculateRescuePercentage()
    {
        _rescuePercentage = (float) PeopleRescued / (float) TotalPeople * 100;


        if (_rescuePercentage == 0f)
        {
            TotalPoints += 0;
        }
        else if(_rescuePercentage < 50f && _rescuePercentage > 0f) 
        {
            TotalPoints += 1;
        }
        else if (_rescuePercentage >= 50f && _rescuePercentage < 100f)
        {
            TotalPoints += 2;
        }
        else if (_rescuePercentage == 100f)
        {
            TotalPoints += 3;
        }

        
    }

    void TransparentSack()
    {
        for(int i = 0; i < GameManager.Instance.Weight; i++) 
        {
            var tempColor = images[i].color;
            tempColor.a = 1f;
            images[i].color = tempColor;
        }
    }
}
