/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GfxMgr : Mgr
{

    public GameObject primaryCamera;
    public Camera cameraComp;
    public GameObject ocean;

    public bool defaultView;
    private PrefabMgr prefabMgrScript;

    public bool cameraHeightLock;
    public int cameraHeightLimit;
    public int cameraSpeed;
    public int cameraFastSpeed;
    public int cameraTurnRate = 90;
    public float cameraHeading;

    private Vector3 lastPos;
    private Vector3 lastRot;
    private Vector3 offset;
    public Vector3 pivotPosition;
    
    // Awake (init) for refrences between scripts, initializations. Runs first even when not enabled
    void Awake()
    {
        cameraComp = (Camera) primaryCamera.GetComponent(typeof(Camera));
    }
    
    // Start (loadLevel) is called before the first frame update only when enabled
    void Start()
    {
        prefabMgrScript = (PrefabMgr) gameObject.GetComponent(typeof(PrefabMgr));
        offset = new Vector3(0, 1, -3);
        pivotPosition = new Vector3();
    }

    // OnApplicationQuit (stop) is called when the application is shutting down
    void OnApplicationQuit()
    {
        
    }

    // Update (tick) is called once per frame. 
    void Update()
    {


        
    }
}