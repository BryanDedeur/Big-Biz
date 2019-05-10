using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    public string DisplayName;
    public float HourlyRate; // the amount of cost the employee will run the manager
    public float WorkTime; // amount of time working can happen
    public float HoldTime; // amount of time until available to collect hourly rate


    public float Intelligence;
    public float Social;
    public float Strength;

    // Start is called before the first frame update
    void Start()
    {
        HourlyRate = 15;
        PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) - (int)HourlyRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
