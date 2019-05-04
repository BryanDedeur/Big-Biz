using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
//[RequireComponent(typeof(CreateUICollider))]
public class LaserTrigger2 : MonoBehaviour
{

    public UnityEvent onClick;
    public UnityStringEvent onClickString;
    private Selectable selectable;

    void Start()
    {
        selectable = GetComponent<Selectable>();
    }

    public void OnPointerClicked()
    {
        onClick.Invoke();
        Text text = GetComponentInChildren<Text>();
        if (text != null)
        {
            //onClickString.Invoke(EnumString.RemoveSpaces(text.text));
        }
    }


    void Update()
    {

    }

    public void onPointerIn()
    {
        if (selectable != null)
        {
            selectable.Select();
        }
    }

    public void onPointerOut()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

}

[System.Serializable]
public class UnityStringEvent : UnityEvent<string> { }
