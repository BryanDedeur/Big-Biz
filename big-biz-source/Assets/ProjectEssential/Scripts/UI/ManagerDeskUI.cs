﻿using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{

    public class ManagerDeskUI : MonoBehaviour
    {
        private GameObject GameManager;
        private EmployeeManager EmployeeMgr;
        private WorkstationManager WorkstationMgr;

        void Start()
        {
            GameManager = GameObject.Find("GameManager");
            EmployeeMgr = GameManager.GetComponent(typeof(EmployeeManager)) as EmployeeManager;
            WorkstationMgr = GameManager.GetComponent(typeof(WorkstationManager)) as WorkstationManager;
        }

        public void HireEmployee()
        {
            EmployeeMgr.SpawnRandomStatEmployee();
        }

        public void SpawnRandomWorkstation()
        {
            WorkstationMgr.SpawnRandomWorkstation();
		}
	}
}