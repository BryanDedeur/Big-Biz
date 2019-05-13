using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoney : MonoBehaviour
{
	void Start()
	{
        PlayerPrefs.SetInt("Money", 0);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Money", 0) <= PlayerPrefs.GetInt("Bankruptcy", 0))
        {
            this.GetComponent<LevelManager>().LoadLevel("LoseScene");
            this.GetComponent<LevelManager>().currentLevel = 0;
        }

        float timeLeft = PlayerPrefs.GetFloat("TimeRemaining", 0);
        timeLeft -= Time.deltaTime;
        PlayerPrefs.SetFloat("TimeRemaining", timeLeft);
        if (timeLeft < 0)
        {
            PlayerPrefs.SetFloat("TimeRemaining", 0);
            this.GetComponent<LevelManager>().LoadLevel("LoseScene");
            this.GetComponent<LevelManager>().currentLevel = 0;
        }
        /* Removed this to load Level 2 instead of auto-win
        else if (PlayerPrefs.GetInt("Money", 0) > 2000)
        {
            this.GetComponent<LevelManager>().LoadLevel("WinScene");
            this.GetComponent<LevelManager>().CleanStart();
        }
        */
    }
}
