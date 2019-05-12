using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUINavigator : MonoBehaviour
{
    private GameObject lastCanvas;

    private void Start()
    {
        lastCanvas = gameObject.transform.Find("MainCanvas").gameObject;
    }


    public void LoadUICanvas(string canvasName)
    {
        GameObject canvas = gameObject.transform.Find(canvasName).gameObject;
        if (canvas)
        {
            if (lastCanvas)
            {
                lastCanvas.SetActive(false);
            }
            canvas.SetActive(true);
            lastCanvas = canvas;
        }
    }
}
