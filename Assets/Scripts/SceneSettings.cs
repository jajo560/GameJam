
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public GameObject PauseMenu;

    [Header("PeopleSetting")]
    public int maxKids;
    public int maxAdults;
    public int maxElder;
    public GameObject KidPrefab;
    public GameObject AdultPrefab;
    public GameObject ElderPrefab;
    public List<Transform> KidSpawns;
    public List<Transform> AdultSpawns;
    public List<Transform> ElderSpawns;

    [Header("Barbie Settings")]
    public GameObject BarbiePrefab;
    public List<Transform> BarbieSpawns;

    [Header("PU Settings")]
    public GameObject ST_PU;
    public GameObject SPE_PU;
    public List<Transform> ST_Spawns;
    public List<Transform> SPE_Spawns;

    // Start is called before the first frame update
    void Start()
    {
        Timer = MaxTime;
        PeopleRescued = 0;

        GetSpawnPoints();

        SpawnPeople();

        SpawnPU();

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.GetComponent<IRescue>() != null)
            {
                TotalPeople++;
            }
        }

        GameManager.Instance.totalPeople = TotalPeople;
    }

    private void SpawnPU()
    {
        int randomST = Random.Range(0, ST_Spawns.Count);
        Instantiate(ST_PU, ST_Spawns[randomST]);

        int randomSPE = Random.Range(0, SPE_Spawns.Count);
        Instantiate(SPE_PU, SPE_Spawns[randomSPE]);
    }

    private void GetSpawnPoints()
    {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "KidSpawn")
            {
                KidSpawns.Add(go.transform);
            }
        }

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "AdultSpawn")
            {
                AdultSpawns.Add(go.transform);
            }
        }

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "ElderSpawn")
            {
                ElderSpawns.Add(go.transform);
            }
        }

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "BarbieSpawn")
            {
                BarbieSpawns.Add(go.transform);
            }
        }

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "SPESpawn")
            {
                SPE_Spawns.Add(go.transform);
            }
        }

        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            if (go.tag == "STSpawn")
            {
                ST_Spawns.Add(go.transform);
            }
        }
    }

    private void SpawnPeople()
    {
        int kids = Random.Range(1, maxKids + 1);
        int adults = Random.Range(1, maxAdults + 1);
        int elder = Random.Range(1, maxElder + 1);

        for (int i = 0; i < kids; i++)
        {
            int index = Random.Range(0, KidSpawns.Count);
            Transform spawn = KidSpawns[index];
            KidSpawns.RemoveAt(index);
            Instantiate(KidPrefab, spawn);
        }

        for (int i = 0; i < adults; i++)
        {
            int index = Random.Range(0, AdultSpawns.Count);
            Transform spawn = AdultSpawns[index];
            AdultSpawns.RemoveAt(index);
            Instantiate(AdultPrefab, spawn);
        }

        for (int i = 0; i < elder; i++)
        {
            int index = Random.Range(0, ElderSpawns.Count);
            Transform spawn = ElderSpawns[index];
            ElderSpawns.RemoveAt(index);
            Instantiate(ElderPrefab, spawn);
        }

        int randomBarbie = Random.Range(0, BarbieSpawns.Count);
        Instantiate(BarbiePrefab, BarbieSpawns[randomBarbie]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeSelf)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseMenu.activeSelf)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        SavedText.text = PeopleRescued + " / " + TotalPeople;

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            TimerText.text = Timer.ToString("00:00");
        }
        else if (Timer <= 0)
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
            GameManager.Instance.peopleRescued = PeopleRescued;
            GameManager.Instance.isDead = GameManager.Instance.IsSafe;
            SceneManager.LoadScene("Puntuation");
        }


    }

    private void CalculateRescuePercentage()
    {
        _rescuePercentage = (float)PeopleRescued / (float)TotalPeople * 100;


        if (_rescuePercentage == 0f)
        {
            TotalPoints += 0;
        }
        else if (_rescuePercentage < 50f && _rescuePercentage > 0f)
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


}
