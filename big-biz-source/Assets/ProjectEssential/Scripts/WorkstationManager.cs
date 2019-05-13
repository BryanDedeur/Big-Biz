using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class WorkstationManager : MonoBehaviour
{
    public string ResourcesPath; // this should start level
    private int NumberResources = 20;

    public List<Workstation> WorkstationList;

    //public GameObject VRThrowable;
    public GameObject SpawnLocation;
    public GameObject WorkstationStatsUI;
    public Vector3 Rescale;
    public SteamVR_ActionSet ActionSet;

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
                    Employee employee = workstation.Employee.GetComponent(typeof(Employee)) as Employee;
                    workstation.Highlight.color = new Color(0, 1, 0, .25f); // Green (Making $$$)
                    workstation.compatibility_text.enabled = true;
                    workstation.compatibility_text.text = (100f * (workstation.intelligence * (employee.intelligence) + workstation.strength * (employee.strength) + workstation.social * (employee.social))) + "% MATCH";
                }
                else
                {
                    workstation.Highlight.color = new Color(1, 1, 1, .25f); // White (Not making $$$)
                    workstation.compatibility_text.enabled = false;
                    // Remove employee's income from global stats
                    //PlayerPrefs.SetInt("Income", PlayerPrefs.GetInt("Income", 0) - workstation.PreviousIncome);

                }
            }
        }
    }

    private void AddInteractionComponents(GameObject newObject)
    {
        MeshCollider mc = newObject.GetComponent(typeof(MeshCollider)) as MeshCollider;
        if (mc)
        {
            mc.convex = true; // if we don't set the mesh collider to convex then the rigidbody will break
        }
        else
        {
            mc = newObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
            mc.convex = true;
        }
        foreach (Transform child in newObject.transform)
        {
            mc = child.gameObject.GetComponent(typeof(MeshCollider)) as MeshCollider;
            if (mc)
            {
                mc.convex = true; // if we don't set the mesh collider to convex then the rigidbody will break
            }
        }


        Rigidbody rb = newObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.mass = 5000000;

        //Throwable tb = newObject.AddComponent(typeof(Throwable)) as Throwable;
        //newObject.AddComponent(typeof(VelocityEstimator));
        //Interactable ib = newObject.GetComponent(typeof(Interactable)) as Interactable;
        //ib.activateActionSetOnAttach = ActionSet;
        //SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Call AI");

        //newObject.AddComponent(typeof(Interactable));

        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public GameObject SpawnRandomWorkstation()
    {
        int randomIndex = Random.Range(1, NumberResources + 1);

        //GameObject throwableClone = Instantiate(VRThrowable, SpawnLocation.transform.position + new Vector3(0, 1, 0), SpawnLocation.transform.rotation) as GameObject;
        GameObject randWorkstationClone = new GameObject();
        try { 
        randWorkstationClone = Resources.Load(ResourcesPath + "workstation (" + randomIndex + ")") as GameObject;

        randWorkstationClone = Instantiate(randWorkstationClone, SpawnLocation.transform.position, randWorkstationClone.transform.rotation) as GameObject;
        randWorkstationClone.transform.localScale = Rescale;

        GameObject statsUI = Instantiate(WorkstationStatsUI, SpawnLocation.transform.position + new Vector3(0, 1.5f, 0), new Quaternion()) as GameObject;
        statsUI.transform.parent = randWorkstationClone.transform;

        AddInteractionComponents(randWorkstationClone);

        //randWorkstationClone.transform.parent = GameObject.Find("WorkStations").transform;
        //InteractableHoverEvents IHE = ThrowableClone.GetComponent(typeof(InteractableHoverEvents)) as InteractableHoverEvents;

        Workstation workstationComponent = randWorkstationClone.AddComponent(typeof(Workstation)) as Workstation;
        WorkstationList.Add(workstationComponent);
        workstationComponent.UI = statsUI;
        }
        catch
        {
            SpawnRandomWorkstation();
        }

        // Cost $$$
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + PlayerPrefs.GetInt("WorkstationPrice", 0));

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
