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

public class Mgr : MonoBehaviour
{
    
    // This is the abstract class for all the managers
    
    // Default constructor
    protected Mgr()
    {
        
    }
    
    // No need for a destructor c# has good garbage collection

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
}
