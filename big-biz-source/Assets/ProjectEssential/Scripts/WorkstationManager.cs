using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationManager : MonoBehaviour
{
    public string ResourcesPath; // this should start level
    private int NumberResources = 21;

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
        foreach (Workstation workstation in WorkstationList)
        {
            if (workstation.Highlight)
            {
                if (workstation.Employee != null)
                {
                    workstation.Highlight.color = new Color(0, 1, 0, .25f); // Green (Making $$$)

                        // Calculate how much $$$ the employee makes
                        //workstation.PreviousIncome = CalculateIncome(workstation);
                        // Add value to income global stats
                        //PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) + workstation.PreviousIncome);
                }
                else
                {
                    workstation.Highlight.color = new Color(1, 1, 1, .25f); // White (Not making $$$)
                        // Remove employee's income from global stats
                    //PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) - workstation.PreviousIncome);
                   
                }
            }
        }
    }

    public GameObject SpawnRandomWorkstation()
    {
        int randomIndex = Random.Range(1, NumberResources + 1);

        GameObject throwableClone = Instantiate(VRThrowable, SpawnLocation.transform.position + new Vector3(0, 1, 0), SpawnLocation.transform.rotation) as GameObject;
        Rigidbody rb = throwableClone.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GameObject randWorkstationClone = Resources.Load(ResourcesPath + "workstation (" + randomIndex + ")") as GameObject;
        GameObject statsUI = Instantiate(WorkstationStatsUI, throwableClone.transform.position + new Vector3(0, 1.5f, 0), new Quaternion()) as GameObject;
        statsUI.transform.parent = throwableClone.transform;
        randWorkstationClone = Instantiate(randWorkstationClone, throwableClone.transform.position, randWorkstationClone.transform.rotation) as GameObject;
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
        workstationComponent.UI = statsUI;

        // Cost $$$
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - 500);

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
