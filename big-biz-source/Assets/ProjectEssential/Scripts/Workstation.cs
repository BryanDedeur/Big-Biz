using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : MonoBehaviour
{

    public float HourlyRate; // the amount of profit the station can provide
    //public float WorkTime; // amount of time working can happen
    //public float HoldTime; // amount of time until available to collect hourly rate
    public GameObject Employee;

    // sum of all weights adds up to 1 (100%)
    public float IntelligenceWeight;
    public float SocialWeight;
    public float StrengthWeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
