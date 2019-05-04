using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityStandardAssets.Characters.ThirdPerson;



[RequireComponent(typeof(Hand))]
public class Laser2 : MonoBehaviour
{
    public SteamVR_Action_Boolean actionClick;
    public Color color = Color.green;
    public Color clickColor = new Color(0, 0.4039f, 0);

    Hand hand;
    GameObject holder;
    GameObject pointer;
    GameObject ball;
    float thickness = 0.002f;
    Transform previousContact = null;

    private GameObject SelectedEmployee;
    private GameObject TargetPositioner;
    public Transform TargetSelecter;


    private void Start()
    {
        hand = gameObject.GetComponent<Hand>();
        if (actionClick == null)
        {
            Debug.LogError("No actionClick has been set on this component.");
        }
        actionClick.actionSet.Activate(hand.handType);

        float dist = 5;
        holder = new GameObject("Holder");
        holder.transform.parent = this.transform;
        ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.parent = holder.transform;
        ball.transform.localPosition = new Vector3(0f, 0f, dist);
        ball.transform.localScale = new Vector3(thickness * 2, thickness * 2, thickness * 2);

        if (hand.handType == SteamVR_Input_Sources.RightHand)
        {
            holder.transform.localRotation = Quaternion.Euler(40, -10, 0);
            holder.transform.localPosition = new Vector3(-0.015f, -0.025f, -0.03f);

            pointer = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pointer.transform.parent = holder.transform;
            pointer.transform.localRotation = Quaternion.Euler(90, 0, 0);
            pointer.transform.localScale = new Vector3(thickness, dist, thickness);
            pointer.transform.localPosition = new Vector3(0f, 0f, dist);
        }
        else
        {
            holder.transform.localRotation = Quaternion.Euler(40, 10, 0);
            holder.transform.localPosition = new Vector3(0.015f, -0.025f, -0.03f);

            pointer = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pointer.transform.parent = holder.transform;
            pointer.transform.localRotation = Quaternion.Euler(90, 0, 0);
            pointer.transform.localScale = new Vector3(thickness, dist, thickness);
            pointer.transform.localPosition = new Vector3(0f, 0f, dist);
        }


        CapsuleCollider colliderCapsule = pointer.GetComponent<CapsuleCollider>();
        if (colliderCapsule)
        {
            Object.Destroy(colliderCapsule);
        }
        SphereCollider colliderSphere = ball.GetComponent<SphereCollider>();
        if (colliderSphere)
        {
            Object.Destroy(colliderSphere);
        }

        pointer.GetComponent<MeshRenderer>().material.color = color;
        pointer.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        pointer.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        pointer.GetComponent<MeshRenderer>().material.SetFloat("_Mode", 2);
        pointer.GetComponent<MeshRenderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        pointer.GetComponent<MeshRenderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        pointer.GetComponent<MeshRenderer>().material.SetInt("_ZWrite", 0);
        pointer.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHATEST_ON");
        pointer.GetComponent<MeshRenderer>().material.EnableKeyword("_ALPHABLEND_ON");
        pointer.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        pointer.GetComponent<MeshRenderer>().material.renderQueue = 3000;

        ball.GetComponent<MeshRenderer>().material.color = color;
        ball.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        ball.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        ball.GetComponent<MeshRenderer>().material.SetFloat("_Mode", 2);
        ball.GetComponent<MeshRenderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        ball.GetComponent<MeshRenderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        ball.GetComponent<MeshRenderer>().material.SetInt("_ZWrite", 0);
        ball.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHATEST_ON");
        ball.GetComponent<MeshRenderer>().material.EnableKeyword("_ALPHABLEND_ON");
        ball.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        ball.GetComponent<MeshRenderer>().material.renderQueue = 3000;
    }

    public void OnPointerIn(UIElement e)
    {
        e.onPointerIn();
        //Debug.Log("OnPointerIn was called.");
    }

    public void OnPointerClick(UIElement e)
    {
        e.OnPointerClicked();
        //Debug.Log("OnPointerClick was called.");
    }

    public void OnPointerOut(UIElement e)
    {
        e.onPointerOut();
        //Debug.Log("OnPointerOut was called.");
    }

    private void DeselectEmployee()
    {
        if (SelectedEmployee)
        {
            GameObject body = SelectedEmployee.transform.Find("EthanBody").gameObject;
            SkinnedMeshRenderer mr = body.GetComponent<SkinnedMeshRenderer>();
            mr.material.color = Color.gray;
            SelectedEmployee = null;
        }
    }

    private void SelectEmployee(GameObject curEmp)
    {
        DeselectEmployee();
        GameObject body = curEmp.transform.Find("EthanBody").gameObject;
        SkinnedMeshRenderer mr = body.GetComponent<SkinnedMeshRenderer>();
        mr.material.color = Color.green;
        SelectedEmployee = curEmp;
    }

    private void Update()
    {
        float dist = 10f;
        Vector3 location = holder.transform.position + 0.0f * holder.transform.forward;
        Ray raycast = new Ray(location, holder.transform.forward);
        RaycastHit hit;
        bool hitOccurred = Physics.Raycast(raycast, out hit);

        //Debug.Log("Ray: " + raycast + ", HitOccured: " + hitOccurred + (hitOccurred ? ", Distance:" + hit.distance + ", Location:" + hit.transform.position : ""));

        AICharacterControl ai = hit.transform.gameObject.GetComponent<AICharacterControl>();
        if (ai)
        {
            SelectEmployee(hit.transform.gameObject);
            // if a previous doesn't exists make a new one
            if (!ai.target)
            {
                ai.target = Instantiate(TargetSelecter).transform;
                TargetPositioner = ai.target.gameObject;
                TargetPositioner.transform.position = hit.transform.position;
            }
            else // do nothing
            {
                TargetPositioner = ai.target.gameObject;
            }
        }

        //Left the previously hit object
        if (previousContact && previousContact != hit.transform)
        {
            UIElement e = previousContact.GetComponent<UIElement>();
            if (e != null)
            {
                OnPointerOut(e);
            }
            previousContact = null;
        }

        //Entered a new object
        if (hitOccurred && previousContact != hit.transform)
        {
            UIElement e = hit.transform.GetComponent<UIElement>();
            if (e != null)
            {
                OnPointerIn(e);
            }
            previousContact = hit.transform;
        }

        //Hit nothing
        if (!hitOccurred)
        {
            previousContact = null;
        }

        //Hit something, so update distance with max of dist
        if (hitOccurred && hit.distance - 0.05f < dist)
        {
            dist = hit.distance;
        }

        //Hit something and the pointer button was clicked
        if (hitOccurred && actionClick.GetStateDown(hand.handType))
        {
            UIElement e = hit.transform.GetComponent<UIElement>();
            if (e != null)
            {
                OnPointerClick(e);
            }
        }

        if (actionClick != null && actionClick.GetState(hand.handType))
        {
            //Pointer button clicked
            pointer.GetComponent<MeshRenderer>().material.color = clickColor;
            pointer.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", clickColor);

            ball.GetComponent<MeshRenderer>().material.color = clickColor;
            ball.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", clickColor);
        }
        else
        {
            //Pointer button not clicked
            pointer.GetComponent<MeshRenderer>().material.color = color;
            pointer.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);

            ball.GetComponent<MeshRenderer>().material.color = color;
            ball.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        }

        //Update laser and ball based on distance
        pointer.transform.localScale = new Vector3(thickness, dist / 2, thickness);
        pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2);
        ball.transform.localPosition = new Vector3(0f, 0f, dist);
    }
}



