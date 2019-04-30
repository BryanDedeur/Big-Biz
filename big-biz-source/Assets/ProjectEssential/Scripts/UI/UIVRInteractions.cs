

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{

    public class UIVRInteractions : MonoBehaviour
    {
        public GameObject Employee;
        public GameObject EmployeeSpawnLocation;
        public GameObject FurnitureSpawnLocation;

        public int randomBandit;
        public GameObject banditClone;

        public void HireEmployee()
        {
            Instantiate(Employee).transform.position = EmployeeSpawnLocation.transform.position;
        }

        public void SpawnRandomWorkstation()
        {
                randomBandit = Random.Range(1, 6); //Random bandit 1-5 (6 is excluded)

                banditClone = Resources.Load("Furniture/Furniture (" + randomBandit + ")") as GameObject;
                Debug.Log(banditClone);
                banditClone = Instantiate(banditClone, FurnitureSpawnLocation.transform.position, transform.rotation) as GameObject;
        }
    }
}