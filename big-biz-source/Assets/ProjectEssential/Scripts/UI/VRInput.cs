using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityStandardAssets.Characters.ThirdPerson;

public class VRInput : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    private EmployeeManager EmployeeMgr;

    protected GameObject hitObject;
    protected RaycastHit rayHit;

    public Transform targetSelecter;

    public float surfaceOffset = .001f;


    public SteamVR_Action_Boolean callaiAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Call AI");
    public SteamVR_Action_Boolean sendaiAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Send AI");

    public SteamVR_Action_Vector2 MovePlayerAction;
    public SteamVR_Action_Vector2 TurnPlayerAction;

    private bool rotateDebounce = false;
    private int debounceCounter = 0;

    private Laser2 laserScript;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            laserScript = GameObject.Find("RightHand").GetComponent(typeof(Laser2)) as Laser2;
        } 
        catch
        {

        }
  

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager)
        {
            EmployeeMgr = gameManager.GetComponent(typeof(EmployeeManager)) as EmployeeManager;
        }

    }

    //private void DeselectEmployee()
    //{
    //    if (SelectedEmployee)
    //    {
    //        GameObject body = SelectedEmployee.transform.Find("EthanBody").gameObject;
    //        SkinnedMeshRenderer mr = body.GetComponent<SkinnedMeshRenderer>();
    //        mr.material.color = Color.gray;
    //        SelectedEmployee = null;
    //    }
    //}

    //private void SelectEmployee(GameObject curEmp)
    //{
    //    DeselectEmployee();
    //    GameObject body = curEmp.transform.Find("EthanBody").gameObject;
    //    SkinnedMeshRenderer mr = body.GetComponent<SkinnedMeshRenderer>();
    //    mr.material.color = Color.green;
    //    SelectedEmployee = curEmp;
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(LeftController.transform.position, LeftController.transform.forward, Color.green);
        //visualRay.transform.forward = LeftController.transform.forward;
        //visualRay.transform.position = LeftController.transform.position;

        //Vector2 moveVec = MovePlayerAction.GetAxis(handType);
        //print(moveVec);
        //gameObject.transform.Translate(new Vector3(moveVec.x, 0, moveVec.y) * Time.deltaTime);
        if (!rotateDebounce)
        {
            rotateDebounce = true;
            Vector2 rotateVec = TurnPlayerAction.GetAxis(inputSource);
            if (rotateVec.x < 0)
            {
                gameObject.transform.Rotate(new Vector3(0, 45 * Mathf.Floor(rotateVec.x), 0));
            } else
            {
                gameObject.transform.Rotate(new Vector3(0, 45 * Mathf.Ceil(rotateVec.x), 0));
            }

        }

        if (debounceCounter == 20)
        {
            debounceCounter = 0;
            rotateDebounce = false;
        }
        debounceCounter += 1;


        if (sendaiAction.GetStateDown(inputSource))
        {
            if (EmployeeMgr)
            {

                EmployeeMgr.SendSelectedEmployeesToTarget(laserScript.ContactPoint);
            }
        }

        //RaycastHit hit;
        //if (Physics.Raycast(LeftController.transform.position, LeftController.transform.forward, out hit))
        //{
        //    // if the raycast hits a employee
        //    AICharacterControl ai = hit.transform.gameObject.GetComponent<AICharacterControl>();
        //    if (ai)
        //    {
        //        SelectEmployee(hit.transform.gameObject);
        //        // if a previous doesn't exists make a new one
        //        if (!ai.target)
        //        {
        //            ai.target = Instantiate(targetSelecter).transform;
        //            targetPositioner = ai.target.gameObject;
        //            targetPositioner.transform.position = hit.transform.position;
        //        }
        //        else // do nothing
        //        {
        //            targetPositioner = ai.target.gameObject;
        //        }
        //    }

        //    if (callaiAction.GetStateUp(handType) && SelectedEmployee)
        //    {
        //        targetPositioner.transform.position = new Vector3(gameObject.transform.position.x, 0.04f, gameObject.transform.position.z) + gameObject.transform.forward;
        //        if (setTargetOn != null)
        //        {
        //            setTargetOn.SendMessage("SetTarget", targetPositioner.transform);
        //        }

        //    }

        //    if (sendaiAction.GetStateUp(handType) && SelectedEmployee)
        //    {
        //        targetPositioner.transform.position = new Vector3(hit.point.x,0.04f, hit.point.z) + new Vector3(hit.normal.x, 0, hit.normal.z) * surfaceOffset;
        //        if (setTargetOn != null)
        //        {
        //            setTargetOn.SendMessage("SetTarget", targetPositioner.transform);
        //        }

        //    }

        //}

        //if (getAIAttention.GetStateUp(handType) && targetPositioner)
        //{
        //    audio.Play();
        //}

    }

}

