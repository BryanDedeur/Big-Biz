using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetMoneyValue : MonoBehaviour
{
	// public GameObject thePlayer;
	public Text displayTo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		displayTo.text = "Money: $" + PlayerPrefs.GetInt("Money", 0);
    }
}
