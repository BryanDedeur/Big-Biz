/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class Prefab381 : MonoBehaviour
{   
    // ------------------------------------ CONSTANT MEMBERS ---------------------------------- //
    // protected int ID;
    public float acceleration = 0;
    public float turnRate = 0;
    public float minSpeed = 0; 
    public float maxSpeed = 0;
    public float collisionRadius = 2;

    
    // Not sure if I should keep abstract constant variables here

    // ------------------------------------ DYNAMIC MEMBERS ---------------------------------- //
    public bool isSelected;
    public Vector3 velocity;
    public float desiredHeading; 
    public float heading;
    public float desiredSpeed;
    public float speed;
    public Prefab381 target;
    public bool isTarget;
    public Transform selector;
    public Transform targeter;
    
    // for air planes
    public float altitude;
    public float desiredAltitude;
    public float climbRate;

    public void GetSelector()
    {
        Transform result = gameObject.transform.Find("selector");

        if (result)
        {
            Debug.Log("Found: " + result);
            selector = result;
        }
        else
        {
            Debug.Log("Did not find: " + result);
            selector = null;
        }
    }
    
    public void GetTargeter()
    {
        Transform result = gameObject.transform.Find("targeter");

        if (result)
        {
            targeter = result;
        }
        else
        {
            targeter = null;
        }
    }
}

public class Battleship : Prefab381
{    
    // Awake even when script is disabled
    void Awake()
    {
        gameObject.name = "battleship";
        acceleration = .05f;
        turnRate = 0.1f;
        minSpeed = 0;
        maxSpeed = 7.5f;
        // gameObject.transform.localScale = gameObject.transform.localScale * 2f;

        
        GetSelector();
        GetTargeter();

        //selector.localScale = new Vector3(5,5,5);
    }
    
    // Start is called before the first frame update only when enabled
    void Start()
    {
        // add aspects
        gameObject.AddComponent<Renderable>();
        gameObject.AddComponent<UnitAI>();
        gameObject.AddComponent<Physics2D>();
    }

}

public class Corvette : Prefab381
{
    // Awake even when script is disabled
    void Awake()
    {
        gameObject.name = "corvette";
        acceleration = 1f;
        turnRate = 20f;
        minSpeed = 0;
        maxSpeed = 10f;
        //gameObject.transform.localScale = gameObject.transform.localScale * .5f;
        
        GetSelector();
        GetTargeter();

        //selector.localScale = new Vector3(3,3,3);

    }
    
    // Start is called before the first frame update only when enabled
    void Start()
    {
        // add aspects
        gameObject.AddComponent<Renderable>();
        gameObject.AddComponent<UnitAI>();
        gameObject.AddComponent<Physics2D>();
    }
    
}

public class Cruiser : Prefab381
 {
     // Awake even when script is disabled
     void Awake()
     {
         gameObject.name = "cruiser";
         acceleration = 1f;
         turnRate = 15f;
         minSpeed = 0;
         maxSpeed = 5f;
         // gameObject.transform.localScale = gameObject.transform.localScale * .5f;
         
         GetSelector();
         GetTargeter();
 
         // selector.localScale = new Vector3(3,3,3);
 
     }
     
     // Start is called before the first frame update only when enabled
     void Start()
     {
         // add aspects
         gameObject.AddComponent<Renderable>();
         gameObject.AddComponent<UnitAI>();
         gameObject.AddComponent<Physics2D>();
     }
     
 }

public class Destroyer : Prefab381
{
    // Awake even when script is disabled
    void Awake()
    {
        gameObject.name = "destroyer";
        acceleration = 1f;
        turnRate = 15f;
        minSpeed = 0;
        maxSpeed = 5f;
        //gameObject.transform.localScale = gameObject.transform.localScale * .5f;
        
        GetSelector();
        GetTargeter();

        //selector.localScale = new Vector3(3,3,3);

    }
    
    // Start is called before the first frame update only when enabled
    void Start()
    {
        // add aspects
        gameObject.AddComponent<Renderable>();
        gameObject.AddComponent<UnitAI>();
        gameObject.AddComponent<Physics2D>();
    }
    
}

public class Frigate : Prefab381
 {
     // Awake even when script is disabled
     void Awake()
     {
         gameObject.name = "frigate";
         acceleration = 1f;
         turnRate = 15f;
         minSpeed = 0;
         maxSpeed = 5f;
         //gameObject.transform.localScale = gameObject.transform.localScale * .5f;
         
         GetSelector();
         GetTargeter();
 
         //selector.localScale = new Vector3(3,3,3);
 
     }
     
     // Start is called before the first frame update only when enabled
     void Start()
     {
         // add aspects
         gameObject.AddComponent<Renderable>();
         gameObject.AddComponent<UnitAI>();
         gameObject.AddComponent<Physics2D>();
     }
     
 }