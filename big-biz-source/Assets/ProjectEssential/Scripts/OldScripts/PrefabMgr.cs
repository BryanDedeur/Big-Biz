/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public class PrefabMgr : Mgr 
{
    // Default constructor
    protected PrefabMgr()
    {
        
    }
    
    public List<Prefab381> prefabList;
    public List<Prefab381> selectedPrefabList;
    
    public GameObject Selector;
    public GameObject Targeter;

    //public GameObject Target; // wont use this instead turn selector red

    // selected assets
    public GameObject Battleship;
    public GameObject Corvette;
    public GameObject Cruiser;
    public GameObject Destroyer;
    public GameObject Frigate;

    //private int numAssets;
    public Prefab381 lastSelection = null;
    
public GameObject SpawnPrefabOfTypeAtPosition(GameObject prefabType, Vector3 newPosition, Quaternion newRotation)
    {    
        //numAssets += 1;
        GameObject newPrefab = null;
        
        if (prefabType == Battleship)
        {
            newPrefab = Instantiate(Battleship, newPosition, newRotation);
            GiveSelector(newPrefab);
            GiveTargeter(newPrefab);
            newPrefab.AddComponent<Battleship>();
        }  
        if (prefabType == Corvette)
        {
            newPrefab = Instantiate(Corvette, newPosition, newRotation);
            GiveSelector(newPrefab);
            GiveTargeter(newPrefab);
            newPrefab.AddComponent<Corvette>();
        }
        if (prefabType == Cruiser)
        {
            newPrefab = Instantiate(Cruiser, newPosition, newRotation);
            GiveSelector(newPrefab);
            GiveTargeter(newPrefab);
            newPrefab.AddComponent<Cruiser>();
        }
        if (prefabType == Destroyer)
        {
            newPrefab = Instantiate(Destroyer, newPosition, newRotation);
            GiveSelector(newPrefab);
            GiveTargeter(newPrefab);
            newPrefab.AddComponent<Destroyer>();
        }
        if (prefabType == Frigate)
        {
            newPrefab = Instantiate(Frigate, newPosition, newRotation);
            GiveSelector(newPrefab);
            GiveTargeter(newPrefab);
            newPrefab.AddComponent<Frigate>();
        }
        
        prefabList.Add((Prefab381) newPrefab.GetComponent(typeof(Prefab381)));
        
        newPrefab.name = (newPrefab.name + prefabList.Count);

        return newPrefab;
    }
    
    // Awake (init) for refrences between scripts, initializations. Runs first even when not enabled
    void Awake()
    {
        
    }
    
    // Start (loadLevel) is called before the first frame update only when enabled
    void Start()
    {
        
    }

    // OnApplicationQuit (stop) is called when the application is shutting down
    void OnApplicationQuit()
    {
        
    }

    // Update (tick) is called once per frame. 
    void Update()
    {
    }

    public void AdjustTargets()
    {
        foreach (Prefab381 prefab in prefabList)
        {
            prefab.isTarget = false;
        }

        foreach (Prefab381 prefab in prefabList)
        {
            if (prefab.target)
            {
                prefab.target.isTarget = true;
            }
        }
    }
    
    public void RemoveAllPrefabTargets()
    {
        foreach (Prefab381 prefab in prefabList)
        {
            if (prefab.target)
            {
                prefab.target = null;
            }
        }
        AdjustTargets();
    }
    
    // this can be cleaned up
    public void MakeTargetForSelectedPrefabs(Prefab381 newTarget)
    {
        //RemoveAllPrefabTargets();
        foreach (Prefab381 prefab in selectedPrefabList)
        {
                if (prefab.transform.root != newTarget.transform.root)
                {
                    prefab.target = newTarget;
                }               

        }

        AdjustTargets();
    }
    
    protected GameObject GiveSelector(GameObject newPrefab)
    {
        GameObject selector = Instantiate(Selector, newPrefab.transform.position, newPrefab.transform.rotation);
        selector.transform.parent = newPrefab.transform;
        selector.name = "selector";
        return selector;
    }
    
    protected GameObject GiveTargeter(GameObject newPrefab)
    {
        GameObject targeter = Instantiate(Targeter, newPrefab.transform.position, newPrefab.transform.rotation);
        targeter.transform.parent = newPrefab.transform;
        targeter.name = "targeter";
        return targeter;
    }
    
    
    // efficiently manage the selection group
    public void AdjustSelectionGroup(Prefab381 prefab, bool deselectOthers)
    {
        // preserve the state of prefab
        bool priorState = prefab.isSelected;
        if (deselectOthers)
        {
            DeselectAll();           
        }

        prefab.isSelected = priorState;
        prefab.isSelected = !prefab.isSelected;
        if (prefab.isSelected)
        {
            selectedPrefabList.Add(prefab);
            lastSelection = prefab;
        }
        else
        {
            selectedPrefabList.Remove(prefab);              
        }
    }
    
    public void SelectAll()
    {
        // if everything is already selected, deselect
        if (selectedPrefabList.Count == prefabList.Count)
            DeselectAll();
        else
        {
            selectedPrefabList.Clear();
            foreach (Prefab381 prefab in prefabList)
            {
                prefab.isSelected = true;
                selectedPrefabList.Add(prefab);
            }
            Debug.Log("Selected All");
        }
    }

    public void DeselectAll()
    {
        foreach (Prefab381 prefab in selectedPrefabList)
        {
            prefab.isSelected = false;
        }
        selectedPrefabList.Clear();
    }

    public void SelectNext()
    {
        // no prefabs to select
        if (prefabList.Count < 1)
        {
            Debug.Log("Not enough prefabs to select");
        }
        else
        {
            // select first prefab if none selected
            if (lastSelection == null)
            {
                lastSelection = prefabList[0];
            }
            else
            {
                DeselectAll();
                bool readyToCapture = false;
                Prefab381 previousPrefab = lastSelection;
                foreach (Prefab381 prefab in prefabList)
                {
                    if (readyToCapture)
                    {
                        lastSelection = prefab;
                        break;
                    }
                    else if (lastSelection == prefab) {
                        readyToCapture = true;
                    }
                }

                if (previousPrefab == lastSelection)
                {
                    lastSelection = prefabList[0];
                }
            }
            
            // by this point the last selection should be the desired prefab
            lastSelection.isSelected = true;
            selectedPrefabList.Add(lastSelection);

        }
    }

}