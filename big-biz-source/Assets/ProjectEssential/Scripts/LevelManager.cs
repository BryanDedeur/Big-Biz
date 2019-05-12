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
           // Player = Instantiate(Resources.Load("DesktopPlayer")) as GameObject;
        }

        MovePlayerToSpawnPos();
    }

    public void MovePlayerToSpawnPos()
    {
        GameObject spawnPos = GameObject.Find("PlayerSpawn");
        if (spawnPos != null && Player != null)
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

    public void UnlockLevelTwo()
    {
        // Temporary for now
        if(PlayerPrefs.GetInt("Money", 0) >= 10000)
        {
            // Pretend they sold the business to start a new one
            PlayerPrefs.SetInt("Income", 0);
            PlayerPrefs.SetInt("Money", 10000);
            SceneManager.LoadScene("Level 2");
        }
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
