using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Team;
    public GameObject PauseMenu;

    public void ExitGame()
    {
        Debug.Log("salgo");
        Application.Quit();
    }

    public void LoadScene
        (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadTeam()
    {
        if(!Team.activeSelf) 
        {
            Team.SetActive(true);
        }
        else
        {
            Team.SetActive(false);
        }
    }

    public void QuitPauseMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
