using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationManager : MonoBehaviour
{
    public string ResourcesPath; // this should start level
    public int NumberResources = 41;

    public List<Workstation> WorkstationList;

    public GameObject VRThrowable;
    public GameObject SpawnLocation;
    public GameObject WorkstationStatsUI;
    public Vector3 Rescale;

    // Start is called before the first frame update
    void Start()
    {
        // finds the spawnlocation in the scene
        SpawnLocation = GameObject.Find("WorkstationSpawnLocation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnRandomWorkstation()
    {
        int randomIndex = Random.Range(1, NumberResources + 1);

        GameObject throwableClone = Instantiate(VRThrowable, SpawnLocation.transform.position + new Vector3(0, 1, 0), SpawnLocation.transform.rotation) as GameObject;
        GameObject randWorkstationClone = Resources.Load(ResourcesPath + "workstation (" + randomIndex + ")") as GameObject;

        randWorkstationClone = Instantiate(randWorkstationClone, throwableClone.transform.position, throwableClone.transform.rotation) as GameObject;
        randWorkstationClone.transform.localScale = Rescale;
        MeshCollider mc = randWorkstationClone.GetComponent(typeof(MeshCollider)) as MeshCollider;
        if (mc)
        {
            mc.convex = true; // if we don't set the mesh collider to convex then the rigidbody will break
        } else
        {
            mc = randWorkstationClone.AddComponent(typeof(MeshCollider)) as MeshCollider;
            mc.convex = true;
        }
        foreach (Transform child in randWorkstationClone.transform)
        {
            mc = child.gameObject.GetComponent(typeof(MeshCollider)) as MeshCollider;
            if (mc)
            {
                mc.convex = true; // if we don't set the mesh collider to convex then the rigidbody will break
            }
        }

        randWorkstationClone.transform.parent = throwableClone.transform;
        //InteractableHoverEvents IHE = ThrowableClone.GetComponent(typeof(InteractableHoverEvents)) as InteractableHoverEvents;

        Workstation workstationComponent = randWorkstationClone.AddComponent(typeof(Workstation)) as Workstation;
        WorkstationList.Add(workstationComponent);

        return randWorkstationClone;
    }



    public void RemoveWorkstation(GameObject workstationToRemove)
    {
        foreach (Workstation station in WorkstationList)
        {
            if (workstationToRemove.GetComponent(typeof(Employee)) == station)
            {
                WorkstationList.Remove(station);
                break;
            }
        }
        Destroy(workstationToRemove);
    }
}
