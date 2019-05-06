using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousLevel()
    {
        // Temporary for now
        SceneManager.LoadScene("StartMenu");
    }

    public void CleanStart()
    {
        // This is actually bad since user settings could potentially be stored this way
        // but this will do for now because we don't have anything other than income and money
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
