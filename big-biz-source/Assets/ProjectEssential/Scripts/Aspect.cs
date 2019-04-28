/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
// This was causing problems in building
// using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

// Abstract aspects class for prefabs
public class Aspect : MonoBehaviour
{
    protected Prefab381 prefab381;
    protected MeshRenderer selectorRenderer;
    protected MeshRenderer headingRenderer;
    
    protected MeshRenderer targetRenderer;


    void Awake()
    {
        prefab381 = (Prefab381) gameObject.GetComponent(typeof(Prefab381));
        if (prefab381.selector != null)
        {
            selectorRenderer = (MeshRenderer) prefab381.selector.GetComponent(typeof(MeshRenderer));
            Transform desiredHeadingMesh = prefab381.selector.Find("desired-heading");
            headingRenderer = (MeshRenderer) desiredHeadingMesh.GetComponent(typeof(MeshRenderer));
            targetRenderer = (MeshRenderer) prefab381.targeter.GetComponent(typeof(MeshRenderer));

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Renderable : Aspect
{
    // Update is called once per frame
    void Update()
    {
        // Render the position change
        gameObject.transform.position = prefab381.transform.position + prefab381.velocity * Time.deltaTime;
        
        // Render the rotation update
        gameObject.transform.rotation = Quaternion.Euler(0, prefab381.heading, 0);
        prefab381.selector.rotation = Quaternion.Euler(0, prefab381.desiredHeading, 0);

        
        // Render the selection box of the prefab
        if (selectorRenderer)
        {
            if (prefab381.isSelected)
            {
                //selectorRenderer.material.color = Color.green;
                selectorRenderer.enabled = true;
                headingRenderer.enabled = true;
            }
            else
            {
                selectorRenderer.enabled = false;
                headingRenderer.enabled = false;                    
            }
        }
        
        if (targetRenderer)
        {
            if (prefab381.isTarget)
            {
                targetRenderer.enabled = true;
            }
            else
            {
                targetRenderer.enabled = false;                 
            }
        }
    }
}

