using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;


public class InteractionMgr : MonoBehaviour
{
    public Camera camera;
    public bool employeeManagementMode = true;
    public Transform targetSelecter;
    RaycastHit hit;
    
    private GameObject lastObject;
    private Color lastColor;
    
    void Update() {
        if (lastObject)
        {
            MeshRenderer mr = lastObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                mr.material.color = lastColor;   
            }
            
        }
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        //camera.transform.Translate(ray.direction * zoomDistance, Space.World);
        if (Physics.Raycast(ray, out hit))
        {
//            if (employeeManagementMode)
//            {
//                AICharacterControl ai = hit.transform.gameObject.GetComponent<AICharacterControl>();
//                if (ai != null)
//                {
//                    ai.target = targetSelecter.transform;
//                }
//            }
            
            AICharacterControl ai = hit.transform.gameObject.GetComponent<AICharacterControl>();
            if (ai)
            {
                if (ai.target)
                {
                    Destroy(ai.target.gameObject);
                }
                ai.target = Instantiate(targetSelecter).transform;
                ai.target.position = camera.transform.position;
            }
       
            //objectHit.transform.GetComponent.<Renderer>().material.color = Color.red;
            lastObject = hit.transform.gameObject;
            MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
            if (mr)
            {
                lastColor = mr.material.color;   
            }
                
            
            //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255,0,0);
        }
        
        Debug.DrawRay(camera.transform.position, ray.direction, Color.green);

    }
}
