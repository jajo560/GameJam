using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GroupPeople : MonoBehaviour
{
    public float speed;
    private Vector3 bunkerPos;
    // Start is called before the first frame update
    void Start()
    {
        bunkerPos = GameObject.FindWithTag("Bunker").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, bunkerPos, speed * Time.deltaTime);

        if(transform.position == bunkerPos)
        {
            gameObject.SetActive(false);
        }

    }
    
    


}
