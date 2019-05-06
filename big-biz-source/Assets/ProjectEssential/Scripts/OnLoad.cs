using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
