using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene ActiveScene;
    private GameObject Player;

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

    //public void CleanStart()
    //{
    //    // This is actually bad since user settings could potentially be stored this way
    //    // but this will do for now because we don't have anything other than income and money
    //    PlayerPrefs.DeleteAll();
    //}

    public void QuitGame()
    {
        Application.Quit();
    }

}
