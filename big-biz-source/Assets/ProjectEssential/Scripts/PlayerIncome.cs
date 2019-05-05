using UnityEngine;

public class PlayerIncome : MonoBehaviour
{
	public int currentPaycheck;
	public float paydayInterval;
	// Start is called before the first frame update
	void Start()
    {
        if (!PlayerPrefs.HasKey("Income"))
        {
            PlayerPrefs.SetInt("Income", currentPaycheck);
            InvokeRepeating("PayDay", paydayInterval, paydayInterval);
        }
	}

    void PayDay()
	{
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + PlayerPrefs.GetInt("Income", 0));
	}
}
