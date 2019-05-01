

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{

    public class UIVRInteractions : MonoBehaviour
    {
        public GameObject GameManager;
        private EmployeeManager EmployeeMgr;
        private WorkstationManager WorkstationMgr;

        void Start()
        {
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

        public void LoadNextLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}