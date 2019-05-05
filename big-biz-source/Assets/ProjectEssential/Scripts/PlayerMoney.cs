using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoney : MonoBehaviour
{
	public int MoneyAmount;
	void Start()
	{
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", MoneyAmount);
        }
    }
}
