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
            DisplayTo.text = "Bankruptcy at -$" + PlayerPrefs.GetInt("Bankruptcy", 0);
        }
	}
}
