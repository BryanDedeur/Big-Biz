using UnityEngine;

public class PlayerIncome : MonoBehaviour
{
    public float paydayInterval;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Income", 0);
        InvokeRepeating("PayDay", paydayInterval, paydayInterval);
    }

    void PayDay()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + PlayerPrefs.GetInt("Income", 0));
    }
}
