using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int peopleRescued;
    public int totalPeople;

    public static GameManager Instance;
    public int Weight;

    public int MaxWeight;

    public bool IsSafe;

    public SceneSettings currentSceneSettings;

    public int PeopleInSack;


    public bool strengthBuff = false;

    public List<Image> images;


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
        SceneManager.sceneLoaded += TransparentSack;

        
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
        Transparent();
    }

    public void AddWeight(int weight)
    {
        if (Weight < MaxWeight)
        {
            Weight += weight;
        }

        for (int i = 0; i < GameManager.Instance.Weight; i++)
        {
            var tempColor = images[i].color;
            tempColor.a = 1f;
            images[i].color = tempColor;
        }
    }

    private void TransparentSack(Scene arg0, LoadSceneMode arg1)
    {
        Transparent();
    }

    private void Transparent()
    {
        foreach (var im in images)
        {
            var tempColor = im.color;
            tempColor.a = .5f;
            im.color = tempColor;
        }
    }
}
