using UnityEngine;
using UnityEngine.UI;

public class GetFinancialStats : MonoBehaviour
{
	// public GameObject thePlayer;
	public Text DisplayTo;
    public string WhichValue;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
        if (WhichValue == "Income")
        {
            DisplayTo.text = "Income: $" + PlayerPrefs.GetInt("Income", 0);
        }
        else if (WhichValue == "Money")
        {
            DisplayTo.text = "Money: $" + PlayerPrefs.GetInt("Money", 0);
        }
        else if (WhichValue == "Bankruptcy")
        {
            DisplayTo.text = "Bankruptcy at -$" + Mathf.Abs(PlayerPrefs.GetInt("Bankruptcy", 0));
        }
        else if (WhichValue == "TimeRemaining")
        {
            DisplayTo.text = "Time remaining " + Mathf.RoundToInt(PlayerPrefs.GetFloat("TimeRemaining", 0)) + " seconds";
        }
        else if (WhichValue == "NextLevelPrice")
        {
            DisplayTo.text = "Go to Next Level $" + PlayerPrefs.GetInt("NextLevelPrice", 0);
        }
        else if (WhichValue == "WorkstationPrice")
        {
            DisplayTo.text = "Workstation: $" + Mathf.Abs(PlayerPrefs.GetInt("WorkstationPrice", 0));
        }
    }
}
