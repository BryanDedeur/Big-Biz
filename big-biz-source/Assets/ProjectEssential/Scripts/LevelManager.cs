using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class LevelManager : MonoBehaviour
{
    public class level
    {
        int levelSecondsUntilGameOver;
    }
    private Scene ActiveScene;
    private GameObject Player;

    public int currentLevel = 0;

    private int[] levelTime = { 180, 240, 240}; // seconds
    private int[] levelBasePrice = { 1000, 3000, 5000};
    private int[] levelWorkstationPrice = { -100, -300, -500 };
    private int[] levelBankruptcy = { -10000, -5000, -3000 };
    private int[] levelWorkstationProfit = { 150, 100, 60 };

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

    private void DeleteExtraPrefabs()
    {
        //ActiveScene = SceneManager.GetSceneByName(sceneName);
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            Debug.Log(g.name);
            if (g.GetComponent(typeof(Interactable))) {
                Destroy(g);
            }
        }
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

        if (ActiveScene.name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            ActiveScene = SceneManager.GetSceneByName(sceneName);
        }
        MovePlayerToSpawnPos();
        PlayerMoney pm = this.GetComponent(typeof(PlayerMoney)) as PlayerMoney;
        if (currentLevel == 0)
        {
            pm.enabled = false;
        }
        else
        {
            pm.enabled = true;
        }
        if (sceneName == "StartMenu")
        {
            currentLevel = 0;
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("NextLevelPrice", 0);
        }
        DeleteExtraPrefabs();

    }

    //public void UnlockLevelTwo()
    //{
    //    // Temporary for now
    //    if(PlayerPrefs.GetInt("Money", 0) >= 2000)
    //    {
    //        // Pretend they sold the business to start a new one
    //        PlayerPrefs.SetInt("Income", 0);
    //        PlayerPrefs.SetInt("Money", 0);
    //        SceneManager.LoadScene("Level 2");
    //    }
    //}

    public void NextLevel()
    {
        
        currentLevel += 1;
        if (currentLevel > 3)
        {
            LoadLevel("WinScene");
        } else
        {
            LoadLevel("Level " + (currentLevel));
            // PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Income", 0);
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("Bankruptcy", levelBankruptcy[currentLevel - 1]);
            PlayerPrefs.SetInt("WorkstationPrice", levelWorkstationPrice[currentLevel - 1]);
            PlayerPrefs.SetInt("WorkstationProfit", levelWorkstationProfit[currentLevel - 1]);
            PlayerPrefs.SetFloat("TimeRemaining", levelTime[currentLevel - 1]);
            PlayerPrefs.SetInt("NextLevelPrice", levelBasePrice[currentLevel - 1]);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
