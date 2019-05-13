using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workstation : MonoBehaviour
{

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

    // Variable for checking if previous iteration updated $$$ from employee
    //public bool HasEmployee;
    public int PreviousIncome;

    public GameObject UI; // will be set by workstation manager
    public Image Highlight;

    public Text intelligence_text, strength_text, social_text, name_text, wage_text, compatibility_text;
    public float intelligence, strength, social, reliability, profit;

    // Start is called before the first frame update
    void Start()
    {
        Transform highlighter = UI.transform.Find("Highlighter");
        Highlight = highlighter.GetComponent(typeof(Image)) as Image;
        //HasEmployee = false;

        profit = Random.Range(PlayerPrefs.GetInt("WorkstationProfit", 0)/4, PlayerPrefs.GetInt("WorkstationProfit", 0));

        GameObject statsUI = UI;
        name_text = statsUI.transform.Find("NameTag").Find("Text").GetComponent(typeof(Text)) as Text;
        intelligence_text = statsUI.transform.Find("Stats").Find("Intelligence").GetComponent(typeof(Text)) as Text;
        strength_text = statsUI.transform.Find("Stats").Find("Strength").GetComponent(typeof(Text)) as Text;
        social_text = statsUI.transform.Find("Stats").Find("Social").GetComponent(typeof(Text)) as Text;
        wage_text = statsUI.transform.Find("Stats").Find("Profit").GetComponent(typeof(Text)) as Text;
        compatibility_text = statsUI.transform.Find("Stats").Find("Compatibility").GetComponent(typeof(Text)) as Text;

        wage_text.text = "Potential Profit: $" + Mathf.Abs(profit) + "/hr";
        intelligence = Random.Range(25, 50) / 100f;
        intelligence_text.text = "Intelligence: " + intelligence * 100 + "%";
        strength = Random.Range(25, 50) / 100f;
        strength_text.text = "Strength: " + strength * 100 + "%";
        social = (1 - (strength + intelligence) );
        social_text.text = "Social: " + social * 100 + "%";
       
    }
}
