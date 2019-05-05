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
        }
        // This might have to be moved inside the if function
        // if we make the money manage do not destroy
		InvokeRepeating("PayDay", paydayInterval, paydayInterval);
	}

    void PayDay()
	{
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + PlayerPrefs.GetInt("Income", 0));
	}
}
