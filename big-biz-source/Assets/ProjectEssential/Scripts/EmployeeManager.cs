using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    
    public GameObject EmployeePrefab;
    public List<Employee> EmployeeList;

    public GameObject SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        // finds the spawnlocation in the scene
        SpawnLocation = GameObject.Find("EmployeeSpawnLocation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnRandomStatEmployee()
    {
        GameObject newEmployee = Instantiate(EmployeePrefab);
        newEmployee.transform.position = SpawnLocation.transform.position;

        Employee employeeComponent = newEmployee.AddComponent(typeof(Employee)) as Employee;
        EmployeeList.Add(employeeComponent);

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
