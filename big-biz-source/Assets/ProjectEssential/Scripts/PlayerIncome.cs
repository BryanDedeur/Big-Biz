using UnityEngine;

public class PlayerIncome : MonoBehaviour
{
    public GameObject gameManager;
    public float paydayInterval;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Income", 0);
        InvokeRepeating("PayDay", paydayInterval, paydayInterval);
    }

    public int CalculateWorkingIncome(Workstation workstation)
    {
        float money = 0;
        Employee employee = workstation.Employee.GetComponent(typeof(Employee)) as Employee;
        if (employee != null)
        {
            money = workstation.profit * (
                workstation.intelligence * (employee.intelligence) +
                workstation.strength * (employee.strength) +
                workstation.social * (employee.social)
                );
            //money = (intelligence * 0.4f + strength * 0.4f + social * 0.2f) * (reliability / 100);
        }
        return Mathf.RoundToInt(money);
    }

    void PayDay()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + PlayerPrefs.GetInt("Income", 0));
    }

    private void Update()
    {
        int totalIncome = 0;
        gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            EmployeeManager em = gameManager.GetComponent(typeof(EmployeeManager)) as EmployeeManager;
            WorkstationManager wm = gameManager.GetComponent(typeof(WorkstationManager)) as WorkstationManager;
            foreach (Workstation workstation in wm.WorkstationList)
            {
                if (workstation.Employee != null)
                {
                    try
                    {
                        totalIncome += CalculateWorkingIncome(workstation);
                    }
                    catch
                    {

                    }
                }
            }
            // this can be simplified
            foreach (Employee employee in em.EmployeeList)
            {
                try
                {
                    totalIncome += Mathf.RoundToInt(employee.wage);
                }
                catch
                {

                }
            }

        }
        PlayerPrefs.SetInt("Income", totalIncome);
    }
}
