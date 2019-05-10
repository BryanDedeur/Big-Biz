using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsGenerator : MonoBehaviour
{
    public Text intelligence_text, strength_text, social_text;
    public int intelligence, strength, social;
    // Start is called before the first frame update
    void Start()
    {
        intelligence = Random.Range(75, 150);
        intelligence_text.text = "Intelligence: " + intelligence;
        strength = Random.Range(75, 150);
        strength_text.text = "Strength: " + strength;
        social = Random.Range(75, 150);
        social_text.text = "Social: " + social;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
