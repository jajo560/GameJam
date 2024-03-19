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

    public SceneSettings currentSceneSettings;

    public int PeopleInSack;

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
        SceneManager.sceneLoaded += GetSceneSettings;
    }

    private void GetSceneSettings(Scene arg0, LoadSceneMode arg1)
    {
        currentSceneSettings = FindAnyObjectByType<SceneSettings>();
    }

    private void ResetWeigth(Scene arg0, LoadSceneMode arg1)
    {
        Weight = 0;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetWeigth;
        SceneManager.sceneLoaded -= GetSceneSettings;
    }
    
    public void SavePeople()
    {
        currentSceneSettings.PeopleRescued += PeopleInSack;
    }

    public void AddWeight(int weight)
    {
        if (Weight < MaxWeight)
        {
            Weight += weight;
        }
    }

 
}
