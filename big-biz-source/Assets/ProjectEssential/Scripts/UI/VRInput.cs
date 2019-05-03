using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityStandardAssets.Characters.ThirdPerson;

public class VRInput : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    public GameObject test;
    public GameObject visualRay;

    public int Heading;

    public SteamVR_ActionSet m_ActionSet;

    //public SteamVR_Action_Boolean CallAI;
    //public SteamVR_Action_Boolean SendAI;
    //public SteamVR_Action_Vector2 m_TouchPosition;
    //public ISteamVR_Action_Vector2 MovePlayer;

    protected GameObject hitObject;
    protected RaycastHit rayHit;

    public GameObject LeftController;
    public Transform targetSelecter;
    private GameObject lastObject;
    //private Color lastColor;

    public float surfaceOffset = .001f;
    public GameObject setTargetOn;

    public GameObject targetPositioner;

    public SteamVR_Action_Boolean callaiAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Call AI");
    public SteamVR_Action_Boolean sendaiAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Send AI");
    //public SteamVR_Action_Boolean getAIAttention = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Shout");
    public SteamVR_Action_Vector2 MovePlayerAction;
    public SteamVR_Action_Vector2 TurnPlayerAction;

    public AudioSource audio;

    public SteamVR_Input_Sources handType;

    private bool rotateDebounce = false;
    private int debounceCounter = 0;

    private void Awake()
    {
        //m_BooleanAction = SteamVR_Actions._default.GrabPinch;
        //MovePlayerAction[SteamVR_Input_Sources.Any].onAxis += AxisTest;

    }

    // Start is called before the first frame update
    void Start()
    {
        m_ActionSet.Activate(handType, 0, true);
    }

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
            Vector2 rotateVec = TurnPlayerAction.GetAxis(handType);
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


        RaycastHit hit;
        if (Physics.Raycast(LeftController.transform.position, LeftController.transform.forward, out hit))
        {
            // if the raycast hits a employee
            AICharacterControl ai = hit.transform.gameObject.GetComponent<AICharacterControl>();
            if (ai)
            {
                // if a previous doesn't exists make a new one
                if (!ai.target)
                {
                    if (ai.target)
                    {
                        Destroy(ai.target.gameObject);
                    }
                    ai.target = Instantiate(targetSelecter).transform;
                    targetPositioner = ai.target.gameObject;
                    targetPositioner.transform.position = hit.transform.position;
                }
                else // do nothing
                {
                    targetPositioner = ai.target.gameObject;
                }
            }

            if (callaiAction.GetStateUp(handType) && targetPositioner)
            {
                print("Call AI");
                targetPositioner.transform.position = new Vector3(gameObject.transform.position.x, 0.04f, gameObject.transform.position.z) + gameObject.transform.forward;
                if (setTargetOn != null)
                {
                    setTargetOn.SendMessage("SetTarget", targetPositioner.transform);
                }
                
            }

            if (sendaiAction.GetStateUp(handType) && targetPositioner)
            {
                print("Send Ai");
                targetPositioner.transform.position = new Vector3(hit.point.x,0.04f, hit.point.z) + new Vector3(hit.normal.x, 0, hit.normal.z) * surfaceOffset;
                if (setTargetOn != null)
                {
                    setTargetOn.SendMessage("SetTarget", targetPositioner.transform);
                }
                targetPositioner = null;
            }

            lastObject = hit.transform.gameObject;
            MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                //lastColor = mr.material.color;
                //mr.material.color = Color.red;
            }

        }

        //if (getAIAttention.GetStateUp(handType) && targetPositioner)
        //{
        //    audio.Play();
        //}

    }


}

