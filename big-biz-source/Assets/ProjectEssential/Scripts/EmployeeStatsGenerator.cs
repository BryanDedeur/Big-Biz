using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeStatsGenerator : MonoBehaviour
{
    public Text intelligence_text, strength_text, social_text, reliability_text, name_text;
    public int intelligence, strength, social, reliability;
    public string EmployeeName;
    readonly string[] maleNames = new string[10] { "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Adam", "Adolph", "Adrian", "Astolfo", "James Bond"};
    // Start is called before the first frame update
    void Start()
    {
        EmployeeName = "Mr. " + maleNames[Random.Range(0,9)];
        name_text.text = EmployeeName;
        intelligence = Random.Range(15, 110);
        intelligence_text.text = "Intelligence: " + intelligence;
        strength = Random.Range(15, 110);
        strength_text.text = "Strength: " + strength;
        social = Random.Range(15, 110);
        social_text.text = "Social: " + social;
        reliability = Random.Range(50, 100);
        reliability_text.text = "Reliability: " + reliability;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
