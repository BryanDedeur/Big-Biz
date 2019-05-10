using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HackIncome(int amount)
    {
        PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) + amount);
    }

    public void HackMoney(int amount)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + amount);
    }
}
