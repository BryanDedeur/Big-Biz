using UnityEngine;

public class PlayerIncome : MonoBehaviour
{
	public int currentPaycheck;
	public float paydayInterval;
	// Start is called before the first frame update
	void Start()
    {
		InvokeRepeating("PayDay", paydayInterval, paydayInterval);
	}

    void PayDay()
	{
		this.GetComponent<PlayerMoney>().MoneyAmount += currentPaycheck;
	}
}
