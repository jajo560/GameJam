using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Weight;

    public int MaxWeight;

    public bool IsSafe;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetWeigth;
    }

    private void ResetWeigth(Scene arg0, LoadSceneMode arg1)
    {
        Weight = 0;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetWeigth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWeight(int weight)
    {
        if (Weight < MaxWeight)
        {
            Weight += weight;
        }
    }
}
