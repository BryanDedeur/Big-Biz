using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeInteractions : MonoBehaviour
{
    public Image NameTag;
    private EmployeeManager EmployeeMgr;
    public void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        EmployeeMgr = gameManager.GetComponent(typeof(EmployeeManager)) as EmployeeManager;
    }

    public void SelectEmployee()
    {
        EmployeeMgr.SelectEmployee(gameObject);
    }
}
