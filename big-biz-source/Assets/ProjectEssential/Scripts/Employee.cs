using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    public Text intelligence_text, strength_text, social_text, reliability_text, name_text;
    public int intelligence, strength, social, reliability, wage;
    public string EmployeeName;
    readonly string[] maleNames = new string[10] { "Aaron", "Abdul", "Wei", "Abel", "Abraham", "Bryan", "Adam", "Adrian", "Astolfo", "James Bond" };
    // Start is called before the first frame update
    void Start()
    {
        GameObject statsUI = gameObject.transform.Find("StatsUI").gameObject;
        name_text = statsUI.transform.Find("NameTag").Find("Text").GetComponent(typeof(Text)) as Text;
        intelligence_text = statsUI.transform.Find("Stats").Find("Intelligence").GetComponent(typeof(Text)) as Text;
        strength_text = statsUI.transform.Find("Stats").Find("Strength").GetComponent(typeof(Text)) as Text;
        social_text = statsUI.transform.Find("Stats").Find("Social").GetComponent(typeof(Text)) as Text;
        reliability_text = statsUI.transform.Find("Stats").Find("Reliability").GetComponent(typeof(Text)) as Text;
        EmployeeName = "Mr. " + maleNames[Random.Range(0, 9)];
        name_text.text = EmployeeName;
        intelligence = Random.Range(15, 110);
        intelligence_text.text = "Intelligence: " + intelligence;
        strength = Random.Range(15, 110);
        strength_text.text = "Strength: " + strength;
        social = Random.Range(15, 110);
        social_text.text = "Social: " + social;
        reliability = Random.Range(50, 100);
        reliability_text.text = "Reliability: " + reliability;
        PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) - 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
