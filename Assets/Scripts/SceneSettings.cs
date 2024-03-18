using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSettings : MonoBehaviour
{
    public float MaxTime;
    public float Time;
    public int TotalPeople;
    public int PeopleRescued;

    // Start is called before the first frame update
    void Start()
    {
        Time = MaxTime;

        foreach(GameObject go in FindObjectsOfType<GameObject>())
        {
            if(go.GetComponent<IRescue>() != null) 
            { 
                TotalPeople++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
