using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EmployeeManager : MonoBehaviour
{
    
    public GameObject EmployeePrefab;
    public List<Employee> EmployeeList;

    private GameObject SpawnLocation;

    public List<GameObject> SelectedEmployeeList;

    public GameObject TargetPoint;

    private bool debounceFlash = false;
    private int debounceCounter = 0;

    private WorkstationManager workstationManager;

    // Start is called before the first frame update
    void Start()
    {
        // finds the spawnlocation in the scene
        SpawnLocation = GameObject.Find("EmployeeSpawnLocation");
        workstationManager = gameObject.GetComponent(typeof(WorkstationManager)) as WorkstationManager;
    }

    private Image FindNameTag(GameObject parent)
    {
        EmployeeInteractions ei = parent.GetComponent(typeof(EmployeeInteractions)) as EmployeeInteractions;
        return ei.NameTag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!debounceFlash)
        {
            debounceFlash = true;
            foreach (GameObject SelectedEmployee in SelectedEmployeeList)
            {
                Image nameTag = FindNameTag(SelectedEmployee);
                if (nameTag.color == new Color(1, 0.92f, 0.016f, .25f))
                {
                    nameTag.color = new Color(1, 1, 1, .50f); // white
                }
                else
                {
                    nameTag.color = new Color(1, 0.92f, 0.016f, .25f); // yellow
                }

            }
        }
        debounceCounter++;
        if (debounceCounter > 50)
        {
            debounceCounter = 0;
            debounceFlash = false;
        }
        foreach (Employee employee in EmployeeList)
        {
            foreach (Workstation workstation in workstationManager.WorkstationList)
            {
                if (workstation.Employee == null)
                {
                    if ((workstation.gameObject.transform.position - employee.gameObject.transform.position).magnitude < 1.5f)
                    {
                        workstation.Employee = employee.gameObject;
                    }
                }
                else if ((workstation.gameObject.transform.position - workstation.Employee.gameObject.transform.position).magnitude > 1.5f)
                {
                    workstation.Employee = null;
                }

            }

        }

    }

    public void SelectEmployee(GameObject employee)
    {
        // check if employee is already selected
        bool employeeAlreadySelected = false;
        foreach(GameObject SelectedEmployee in SelectedEmployeeList)
        {
            if (SelectedEmployee == employee)
            {
                FindNameTag(employee).color = new Color(1, 1, 1, .25f);
                employeeAlreadySelected = true;
                SelectedEmployeeList.Remove(SelectedEmployee);
                break;
            }
        }
        if (!employeeAlreadySelected)
        {
            SelectedEmployeeList.Add(employee);
        }
    }

    public void DeselectAllEmployees()
    {
        for (int index = 0; index < SelectedEmployeeList.Count; index++)
        {
            FindNameTag(SelectedEmployeeList[index]).color = new Color(1, 1, 1, .25f);
        }
        SelectedEmployeeList.Clear();
    }

    public void SendSelectedEmployeesToTarget()
    {
        GameObject RH = GameObject.Find("RightHand");
        if (RH)
        {
            Laser2 laser = RH.GetComponent(typeof(Laser2)) as Laser2;
            if (laser)
            {
                foreach (GameObject SelectedEmployee in SelectedEmployeeList)
                {
                    AICharacterControl ai = SelectedEmployee.GetComponent<AICharacterControl>();
                    if (ai.target)
                    {
                        Destroy(ai.target.gameObject);
                    }
                    ai.target = Instantiate(TargetPoint).transform;
                    ai.target.position = new Vector3(laser.ContactPoint.x, .05f, laser.ContactPoint.z);

                }
                DeselectAllEmployees();
            }
        }

    }

    public void SendSelectedEmployeesToTarget(Vector3 location)
    {
        foreach (GameObject SelectedEmployee in SelectedEmployeeList)
        {
            AICharacterControl ai = SelectedEmployee.GetComponent<AICharacterControl>();
            if (ai.target)
            {
                Destroy(ai.target.gameObject);
            }
            ai.target = Instantiate(TargetPoint).transform;
            ai.target.position = new Vector3 (location.x, .05f, location.z);

        }
        DeselectAllEmployees();
    }

    public GameObject SpawnRandomStatEmployee()
    {
        GameObject newEmployee = Instantiate(EmployeePrefab);
        newEmployee.transform.position = SpawnLocation.transform.position;

        Employee employeeComponent = newEmployee.AddComponent(typeof(Employee)) as Employee;
        EmployeeList.Add(employeeComponent);
        employeeComponent.wage = Random.Range(-30, -10);

        // Add random stats here

        return newEmployee;
    }

    public void RemoveEmployee(GameObject employeeToRemove)
    {
        foreach (Employee emp in EmployeeList)
        {
            if (employeeToRemove.GetComponent(typeof(Employee)) == emp)
            {
                EmployeeList.Remove(emp);
                break;
            }
        }
        Destroy(employeeToRemove);
    }
}
