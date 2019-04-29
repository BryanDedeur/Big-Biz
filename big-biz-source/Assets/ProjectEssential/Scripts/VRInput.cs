using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInput : MonoBehaviour
{
    public GameObject test;

    public SteamVR_Action_Boolean m_BooleanAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BooleanAction[SteamVR_Input_Sources.LeftHand].stateDown)
        {
            Debug.Log("OKAy");
        }
    }
}
