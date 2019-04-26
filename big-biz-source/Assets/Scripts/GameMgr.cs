/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Component = System.ComponentModel.Component;

public class GameMgr : Mgr
{
    public int PrefabSpacing;
    
    private PrefabMgr prefabMgrScript;
    
    // Awake (init) for refrences between scripts, initializations. Runs first even when not enabled
    void Awake()
    {
        
    }
    
    
    // Start (loadLevel) is called before the first frame update only when enabled
    void Start()
    {
        // gets the prefab manager
        prefabMgrScript = (PrefabMgr) gameObject.GetComponent(typeof(PrefabMgr));

        // ------------------ SPAWN GAME ASSETS NOT ALREADY IN SCENE -----------------------//
        // set default position and orientation
        Vector3 spawnPos = new Vector3((float)(-PrefabSpacing * (5 - 1) / 2f ),-2,0);
        Quaternion defaultOrientation = new Quaternion();

        prefabMgrScript.SpawnPrefabOfTypeAtPosition(prefabMgrScript.Battleship, spawnPos, defaultOrientation);
        spawnPos.x += PrefabSpacing;
        prefabMgrScript.SpawnPrefabOfTypeAtPosition(prefabMgrScript.Corvette, spawnPos, defaultOrientation);
        spawnPos.x += PrefabSpacing;
        prefabMgrScript.SpawnPrefabOfTypeAtPosition(prefabMgrScript.Cruiser, spawnPos, defaultOrientation);
        spawnPos.x += PrefabSpacing;
        prefabMgrScript.SpawnPrefabOfTypeAtPosition(prefabMgrScript.Destroyer, spawnPos, defaultOrientation);
        spawnPos.x += PrefabSpacing;
        prefabMgrScript.SpawnPrefabOfTypeAtPosition(prefabMgrScript.Frigate, spawnPos, defaultOrientation);

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
