using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUINavigator : MonoBehaviour
{
    public GameObject lastCanvas;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            LevelManager lm = player.GetComponent(typeof(LevelManager)) as LevelManager;
            lm.MovePlayerToSpawnPos();
        }
        if (lastCanvas == null)
        {
            lastCanvas = new GameObject();
        }
        
        
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("Money", 0) >= PlayerPrefs.GetInt("NextLevelPrice", 0))
        {
            GameObject player = GameObject.Find("Player");
            if (player)
            {
                LevelManager lm = player.GetComponent(typeof(LevelManager)) as LevelManager;
                lm.NextLevel();
            }
        }
    }

    public void LoadLevel(string level)
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            LevelManager lm = player.GetComponent(typeof(LevelManager)) as LevelManager;
            lm.LoadLevel(level);
        }
    }

    public void QuitGame()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            LevelManager lm = player.GetComponent(typeof(LevelManager)) as LevelManager;
            lm.QuitGame();
        }
    }


    public void LoadUICanvas(string canvasName)
    {
        GameObject canvas = gameObject.transform.Find(canvasName).gameObject;
        if (canvas)
        {
            if (lastCanvas)
            {
                lastCanvas.SetActive(false);
            }
            canvas.SetActive(true);
            lastCanvas = canvas;
        }
    }
}
