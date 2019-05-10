using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene ActiveScene;
    private GameObject Player;
    public GameObject DesktopPlayer;

    private void Start()
    {
        Player = GameObject.Find("Player");
        if (Player)
        {
            Debug.Log("Player found");
        } 
        else
        {
            Debug.Log("Player not found");
           // Player = Instantiate(Resources.Load("DesktopPlayer")) as GameObject;
        }

        MovePlayerToSpawnPos();
    }

    public void MovePlayerToSpawnPos()
    {
        GameObject spawnPos = GameObject.Find("PlayerSpawn");
        if (spawnPos != null)
        {
            Player.transform.position = spawnPos.transform.position;
            Player.transform.rotation = spawnPos.transform.rotation;
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        ActiveScene = SceneManager.GetSceneByName(sceneName);
        MovePlayerToSpawnPos();

    }

    public void ReturnToPreviousLevel()
    {
        // Temporary for now
        SceneManager.LoadScene("StartMenu");
    }

    public void CleanStart()
    {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Income", 0);
        PlayerPrefs.SetInt("Money", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
