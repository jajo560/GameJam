using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour, IRescue
{
    public int weight => 1;

    public void Rescue()
    {
        

        if (GameManager.Instance.strengthBuff)
        {
            int newWeight;
            newWeight = Mathf.RoundToInt(weight * 0.5f);
            Debug.Log(newWeight);
            GameManager.Instance.AddWeight(newWeight);
        }
        else 
        {
            GameManager.Instance.AddWeight(weight);
        }
        
    }

   
}
