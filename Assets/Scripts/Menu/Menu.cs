using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
}
