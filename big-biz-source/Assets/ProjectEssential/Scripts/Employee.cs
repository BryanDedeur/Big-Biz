using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    public Text intelligence_text, strength_text, social_text, reliability_text, name_text, wage_text;
    public float intelligence, strength, social, reliability, wage;
    public string EmployeeName;
    public bool isWorking;
    readonly string[] names = new string[] { "Alfredo", "Kyle", "Kevin", "Andrew", "Deeptanshu", "Bryan", "Michael", "Alexis", "William", "Benjamin", "Braulio", "Nicholas", "Sidney", "Erik", "Maxwell", "Nicholas", "Alexander", "Eryl", "Justin", "Casey", "Sushil", "Aaron", "Miles", "Jonathan", "Bryce", "Garrett", "Allan", "Nathan", "Courtney", "Ethan", "Alexander", "Deev", "Gianni", "Price", "Braeden", "Cody", "Enrique", "Wei", "David", "Ryan", "Carlos", "Christine", "Terra", "Dmitri" };
    // Start is called before the first frame update
    void Start()
    {
        GameObject statsUI = gameObject.transform.Find("StatsUI").gameObject;
        name_text = statsUI.transform.Find("NameTag").Find("Text").GetComponent(typeof(Text)) as Text;
        intelligence_text = statsUI.transform.Find("Stats").Find("Intelligence").GetComponent(typeof(Text)) as Text;
        strength_text = statsUI.transform.Find("Stats").Find("Strength").GetComponent(typeof(Text)) as Text;
        social_text = statsUI.transform.Find("Stats").Find("Social").GetComponent(typeof(Text)) as Text;
        reliability_text = statsUI.transform.Find("Stats").Find("Reliability").GetComponent(typeof(Text)) as Text;
        wage_text = statsUI.transform.Find("Stats").Find("Wage").GetComponent(typeof(Text)) as Text;
        EmployeeName = names[Random.Range(0, 44-1)];
        name_text.text = EmployeeName;
        wage_text.text = "Wage: $" + Mathf.Abs(wage) + "/hr";
        intelligence = Random.Range(50, 100) / 100f;
        intelligence_text.text = "Intelligence: " + intelligence * 100 + "%";
        strength = Random.Range(50, 100) / 100f;
        strength_text.text = "Strength: " + strength * 100 + "%";
        social = Random.Range(50, 100)/100f;
        social_text.text = "Social: " + social * 100 + "%";
        reliability = Random.Range(50, 100) / 100f;
        reliability_text.text = "Reliability: " + reliability * 100 + "%";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
