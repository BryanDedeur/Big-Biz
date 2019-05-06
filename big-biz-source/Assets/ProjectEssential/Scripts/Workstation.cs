using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //public bool workable = true;

    private float TimeUntilActive;
    private float WorkableTime;

    public GameObject UI; // will be set by workstation manager
    public Image Highlight;

    // Start is called before the first frame update
    void Start()
    {
        Transform highlighter = UI.transform.Find("Highlighter");
        Highlight = highlighter.GetComponent(typeof(Image)) as Image;
    }
}
