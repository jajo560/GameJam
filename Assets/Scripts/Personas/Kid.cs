using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour, IRescue
{
    public int weight => 1;

    public void Rescue()
    {
        GameManager.Instance.AddWeight(weight);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
