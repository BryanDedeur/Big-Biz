using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    public GameObject player;
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        var rot = player.transform.rotation;
        rot.x = 0;
        rot.z = 0;
        transform.LookAt(transform.position + rot * Vector3.forward, Vector3.up);
    }

    private void Start()
    {
        //player = GameObject.Find("Player").transform.Find("SteamVRObjects").Find("VRCamera").gameObject.GetComponent(typeof(Camera)) as Camera;
        player = GameObject.Find("Player").transform.Find("SteamVRObjects").Find("VRCamera").Find("FollowHead").gameObject;
    }
}
