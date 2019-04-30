

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
        public GameObject VRThrowable;

        private int randomFurniture;
        private GameObject ThrowableClone;
        private GameObject FurnitureClone;

        public void HireEmployee()
        {
            Instantiate(Employee).transform.position = EmployeeSpawnLocation.transform.position;
        }

        public void SpawnRandomWorkstation()
        {
            randomFurniture = Random.Range(1, 94);

            ThrowableClone = Instantiate(VRThrowable, FurnitureSpawnLocation.transform.position + new Vector3(0, 1, 0), transform.rotation) as GameObject;
            FurnitureClone = Resources.Load("Furniture/Furniture (" + randomFurniture + ")") as GameObject;

            FurnitureClone = Instantiate(FurnitureClone, ThrowableClone.transform.position, ThrowableClone.transform.rotation) as GameObject;
            FurnitureClone.transform.parent = ThrowableClone.transform;
            MeshCollider mc = FurnitureClone.GetComponent(typeof(MeshCollider)) as MeshCollider;
            mc.convex = true;
            if (mc.convex)
            {
                //FurnitureClone.AddComponent(typeof(SteamVR_Skeleton_Poser));
                //FurnitureClone.AddComponent(typeof(Throwable));
                //FurnitureClone.AddComponent(typeof(Interactable));
                //FurnitureClone.AddComponent(typeof(Rigidbody));
            }
            //InteractableHoverEvents IHE = ThrowableClone.GetComponent(typeof(InteractableHoverEvents)) as InteractableHoverEvents;
            

        }
    }
}