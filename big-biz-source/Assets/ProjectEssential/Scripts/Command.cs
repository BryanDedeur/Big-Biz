/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;


// Unit AI manages commands
public class Command : MonoBehaviour
{
    protected Prefab381 prefab381;

    protected UnitAI unitAIScript;

    public bool isFinished;

    protected GameObject target;

    protected float abortDistance = 0f;
    
    
    void Awake()
    {
        unitAIScript = (UnitAI) gameObject.GetComponent(typeof(UnitAI));
        prefab381 = (Prefab381) gameObject.GetComponent(typeof(Prefab381));

    }

    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {


    }
}


//
public class MoveTo : Command
{
    protected UnityEngine.Vector3 gapVector;
    
    
    // Update is called once per frame
    void Update()
    {

        
        //gapVector = prefab381.target.transform.position;

        gapVector = (unitAIScript.trackTarget.transform.position - gameObject.transform.position);
        prefab381.desiredHeading = Mathf.Rad2Deg * Mathf.Atan2(gapVector.x, gapVector.z);

        // a potential strategy to end the AI
        /*
        float gap = Mathf.Sqrt(((int)gapVector.x ^ 2) + ((int)gapVector.y ^ 2) + ((int)gapVector.z ^ 2));
        print(gap);
        if (gap > abortDistance)
        {
        }
        else
        {
            isFinished = true;
        }
        */
        

        // how this works: 
        // get vector to me from origin

        // get vector to point from origin
        // get dif vector (dif = point - me)

        // use dif to compute desired heading (atan2(x/z)


    }
}