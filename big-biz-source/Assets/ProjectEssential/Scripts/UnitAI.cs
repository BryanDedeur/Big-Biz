/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


// Unit AI manages commands
public class UnitAI : Aspect
{
    public bool AIinProgress;
    // The commands will be enqueued and dequeued   
    protected Queue<Command> commandList;
    public Prefab381 trackTarget;

    void Start()
    {
        AIinProgress = false;
        commandList = new Queue<Command>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trackTarget && !AIinProgress)
        {
            AIinProgress = true;
            //prefab381.desiredSpeed = 10f;
            // enqueue command
            MoveTo newCommand = gameObject.AddComponent<MoveTo>();
            commandList.Enqueue(newCommand);
            //trackTarget = prefab381.target;
        }

        if (commandList.Count != 0)
        {
            Command peekResult = commandList.Peek();
            if (peekResult)
            {
                if (peekResult.isFinished)
                {
                    AIinProgress = false;
                    Destroy(commandList.Dequeue());      
                }
            }           
        }

        
        /*
        if (prefab381)
        {
            // if prefab381 has target then add command once! Not sure how to properly set this up
            if (!prefab381.isAIControlled)
            {
                prefab381.isAIControlled = true;
            
                // enqueue command
                Command newCommand = prefab381.gameObject.AddComponent<Command>();
                commandList.Enqueue(newCommand);

            }

            // check if first command is done? Or is target no longer available
            if (commandList.Peek().isFinished || !prefab381.target)
            {
                commandList.Dequeue();
            }

            if (commandList.Count == 0)
            {
                prefab381.isAIControlled = false;
            }
        
            // or check if the whole list needs to be cleared            
        }
        */
    }
}