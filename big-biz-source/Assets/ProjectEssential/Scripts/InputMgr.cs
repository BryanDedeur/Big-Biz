/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class InputMgr : Mgr
{
    private PrefabMgr prefabMgrScript;
    
    // Default constructor
    public InputMgr()
    {
        
    }
    
    // ------------------------------------ General Controls ---------------------------------- //

    
    public KeyCode shutDownGame;
    public KeyCode toggleCamera;

    
    // ------------------------------------ Camera Controls ---------------------------------- //
    
    public KeyCode cameraForward;
    public KeyCode cameraBoost;
    public KeyCode cameraBackward;
    public KeyCode cameraLeft;
    public KeyCode cameraRight;
    public KeyCode cameraUp;
    public KeyCode cameraDown;
    public KeyCode cameraRotate;
    
    // ------------------------------------ Prefab Controls ---------------------------------- //

    public KeyCode selectNextPrefab;
    public KeyCode groupSelect;

    public KeyCode increaseSpeed;
    public KeyCode decreaseSpeed;
    public KeyCode increaseHeading;
    public KeyCode decreaseHeading;
    public KeyCode stopAll;
    public KeyCode increaseAltitude;
    public KeyCode decreaseAltitude;
    
    private GfxMgr gfxMgrScript;
    
    private Vector3 startPos;

    // Awake (init) for refrences between scripts, initializations. Runs first even when not enabled
    void Awake()
    {
 
    }
    
    // Start (loadLevel) is called before the first frame update only when enabled
    void Start()
    {        
        // gets the managers

        gfxMgrScript = (GfxMgr) gameObject.GetComponent(typeof(GfxMgr));
        prefabMgrScript = (PrefabMgr) gameObject.GetComponent(typeof(PrefabMgr));

    }

    // OnApplicationQuit (stop) is called when the application is shutting down
    void OnApplicationQuit()
    {
        
    }

    // Update (tick) is called once per frame. 
    void Update()
    {
        // ------------------------------- GENERAL CONTROLS --------------------------------- //
        
        if (Input.GetKey(shutDownGame))
        {
            Application.Quit(); // this doesn't work for some reason
        }
        
        if (Input.GetKeyDown(toggleCamera))
        {
            gfxMgrScript.defaultView = !gfxMgrScript.defaultView;
        }

        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            print("Mouse left button down at: " + startPos);
            // this method can be costly depending on the hit box detection
            Ray ray = gfxMgrScript.cameraComp.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                 // if hit is a prefab
                 foreach (Prefab381 prefab in prefabMgrScript.prefabList)
                 {
                     if (prefab.transform.root == hit.transform.root)
                     {
                         prefabMgrScript.AdjustSelectionGroup(prefab, !Input.GetKey(groupSelect));
                     }
                 }
            }
            
            // attempt to calculate the projected vector from prefab to click ray to detect nearest. However the distance is not increasing as camera pans out.
            /*
            foreach (Prefab381 prefab in prefabMgrScript.prefabList)
            {
                //Vector3 forward = transform.TransformDirection(Vector3.forward);
                Ray ray = gfxMgrScript.cameraComp.ScreenPointToRay(Input.mousePosition);

                // make a vector from camera to prefab
                Vector3 toOther = prefab.transform.position;
                float dotProduct = Vector3.Dot( toOther, ray.GetPoint(1));

                print("Prefab: " + prefab.name + " returned a dot product of size " + dotProduct);     
            }
            */
            
        }
        
        // Right click
        if (Input.GetMouseButtonDown(1))
        {
            
            prefabMgrScript.RemoveAllPrefabTargets();

            print("Mouse right button down at: " + startPos);
            // this method can be costly depending on the hit box detection
            Ray ray = gfxMgrScript.cameraComp.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Prefab381 rightClickedPrefab = null;
                foreach (Prefab381 prefab in prefabMgrScript.prefabList)
                {
                    if (prefab.transform.root == hit.transform.root)
                    {
                        rightClickedPrefab = prefab;
                        break;
                    }
                }

                if (rightClickedPrefab)
                {
                    //prefabMgrScript.MakeTargetForSelectedPrefabs(rightClickedPrefab);
                    foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
                    {
                        UnitAI AIfound = ((UnitAI) prefab.GetComponent(typeof(UnitAI)));
                        if (AIfound)
                        {
                            if (AIfound.trackTarget)
                            {
                                if (AIfound.trackTarget.transform.root == rightClickedPrefab.gameObject.transform.root)
                                {
                                    AIfound.trackTarget = null;
                                    rightClickedPrefab.isTarget = false;
                                }
                                else
                                {
                                    AIfound.trackTarget = rightClickedPrefab;
                                    rightClickedPrefab.isTarget = true;

                                }
                            }
                            else
                            {
                                AIfound.trackTarget = rightClickedPrefab;
                                rightClickedPrefab.isTarget = true;
                            }
                        }


                    }
                }

                

                /*
                if (rightClickedPrefab)
                {
                    foreach (Prefab381 prefab in prefabMgrScript.prefabList)
                    {
                        if (prefab.isSelected)
                        {
                            // check if new target is same as old target OR if prefab is the same selected prefab
                            if (prefab.target)
                            {
                                if (prefab.target.transform.root == rightClickedPrefab.transform.root)
                                {
                                    prefab.target = null;
                                } 
                            } 
                            else if (rightClickedPrefab.transform.root != prefab.transform.root)
                            {
                                prefab.target = rightClickedPrefab;
                            }
                            
  
                            
                        // sudo code
                        // for every prefab that is selected
                        // check to make sure newly found prefab is not already target
                        // if so set target to null
                        // else
                        // set its target to the newly found prefab 
                        }
                    }

                    prefabMgrScript.AdjustTargets();
                }
                */
            }      
        }
        
        // Multi Selection captures on mouse release
        if(Input.GetMouseButtonUp(0)) {
            print("Mouse left button up at: " + Input.mousePosition);
            
            float xmin = Mathf.Min(startPos.x, Input.mousePosition.x);
            float ymin = Mathf.Min(startPos.y, Input.mousePosition.y);
            float width = Mathf.Max(startPos.x, Input.mousePosition.x) - xmin;
            float height = Mathf.Max(startPos.y, Input.mousePosition.y) - ymin;
            Rect dragBox = new Rect(xmin, ymin, width, height);
            
            foreach (Prefab381 prefab in prefabMgrScript.prefabList) {
                Vector3 objectLoc = gfxMgrScript.cameraComp.WorldToScreenPoint(prefab.transform.position);
                     
                if(dragBox.Contains(objectLoc)) {
                    prefabMgrScript.AdjustSelectionGroup(prefab, false);
                }
            }
        }
    

        
        // ------------------------------- RELATIVE CAMERA CONTROLS ---------------------------------- //
        
        Vector3 movementVec = new Vector3();
        int rotateDir = 0;
        
        if (Input.GetKey(cameraForward))
        {
            movementVec.z += 1;
        }
        if (Input.GetKey(cameraBackward))
        {
            movementVec.z -= 1;
        }
        if (Input.GetKey(cameraRight))
        {
            movementVec.x += 1;
        }
        if (Input.GetKey(cameraLeft))
        {
            movementVec.x -= 1;
        }
        if (Input.GetKey(cameraRotate))
        {
           rotateDir -= 1;
        }
        /*
        if (Input.GetKey(cameraUp))
        {
            movementVec.y += 1;
        }
        if (Input.GetKey(cameraDown))
        {
            movementVec.y += -1;
        }
        
        */
        // Apply changes to camera
        if (movementVec != new Vector3())
        {
            if (Input.GetKey(cameraBoost))
            {
                gfxMgrScript.pivotPosition += movementVec * 2 * gfxMgrScript.cameraSpeed * Time.deltaTime;
                //gfxMgrScript.primaryCamera.transform.Translate();
            }
            else
            {
                gfxMgrScript.pivotPosition += movementVec * 1 * gfxMgrScript.cameraSpeed * Time.deltaTime;
                //gfxMgrScript.primaryCamera.transform.Translate(movementVec * gfxMgrScript.cameraSpeed * Time.deltaTime); 
            }
        }

        if (rotateDir != 0)
        {
            //gfxMgrScript.primaryCamera.transform.Rotate(0, rotateDir * gfxMgrScript.cameraTurnRate * Time.deltaTime, 0, Space.Self);
            //gfxMgrScript.primaryCamera.transform.rotation = Quaternion.Euler(0, gfxMgrScript.primaryCamera.transform.rotation.y + rotateDir * gfxMgrScript.cameraTurnRate * Time.deltaTime, 0);
            gfxMgrScript.cameraHeading += rotateDir * gfxMgrScript.cameraTurnRate * Time.deltaTime;
        }

        if (prefabMgrScript.lastSelection)
        {
            gfxMgrScript.primaryCamera.transform.position = prefabMgrScript.lastSelection.transform.position + new Vector3(20, 10, -20);
            //primaryCamera.transform.rotation = prefabMgrScript.lastSelection.transform.rotation;
        }

        if (gfxMgrScript.defaultView)
        {
            if (gfxMgrScript.cameraHeightLock)
            {
                //gfxMgrScript.primaryCamera.transform.position = gfxMgrScript.pivotPosition;
                //gfxMgrScript.primaryCamera.transform.rotation = Quaternion.Euler(30, gfxMgrScript.cameraHeading, 0);
                //gfxMgrScript.primaryCamera.transform.Translate(new Vector3(0,gfxMgrScript.cameraHeightLimit, -100));


                //primaryCamera.transform.position = new Vector3(primaryCamera.transform.position.x, cameraHeightLimit, primaryCamera.transform.position.z);
            }
        } else {
            //gfxMgrScript.lastPos = gfxMgrScript.primaryCamera.transform.position;
            //lastRot = primaryCamera.transform.rotation.;
            if (prefabMgrScript.lastSelection)
            {
                //gfxMgrScript.primaryCamera.transform.position = prefabMgrScript.lastSelection.transform.position + gfxMgrScript.offset * 4;
                //primaryCamera.transform.rotation = prefabMgrScript.lastSelection.transform.rotation;
            }
        }
        
        // ------------------------------- PREFAB CONTROLS ---------------------------------- //
                
        if (Input.GetKeyDown(selectNextPrefab))
        {
            prefabMgrScript.SelectNext();
        }
        
        if (Input.GetKeyDown(KeyCode.A) && ((Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl))))
        {
            prefabMgrScript.SelectAll();
        }
        
        if (Input.GetKey(stopAll))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredSpeed = 0;
            }
        }

        float incrementSize = .5f;
        
        if (Input.GetKey(increaseSpeed))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredSpeed += incrementSize;
            }
        }
        
        if (Input.GetKey(decreaseSpeed))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredSpeed -= incrementSize;
            }
        }
        
        if (Input.GetKey(increaseHeading))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredHeading += incrementSize;
            }
        }
        
        if (Input.GetKey(decreaseHeading))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredHeading -= incrementSize;
            }
        }
        
        if (Input.GetKey(increaseAltitude))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredAltitude += incrementSize;
            }
        }
        
        if (Input.GetKey(decreaseAltitude))
        {
            foreach (Prefab381 prefab in prefabMgrScript.selectedPrefabList)
            {
                prefab.desiredAltitude -= incrementSize;
            }
        }
    }
}
