using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Weight;

    public int MaxWeight;

    public bool IsSafe;

    public SceneSettings currentSceneSettings;

    [Header("Sack Settings")]
    public int PeopleInSack;
    public List<Image> PeopleList;

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

        TransparentPeople();
    }

    private void Start()
    {
        TransparentPeople();
    }

    private void TransparentPeople()
    {
        foreach (var item in PeopleList)
        {
            var tempColor = item.color;
            tempColor.a = .5f;
            item.color = tempColor;
        }
    }

    public void AddWeight(int weight)
    {
        if (Weight < MaxWeight)
        {
            Weight += weight;
        }

        for (int i = 0; i < Weight; i++)
        {
            var tempColor = PeopleList[i].color;
            tempColor.a = 1f;
            PeopleList[i].color = tempColor;
        }
    }
}
