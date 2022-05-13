using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWithButtons : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] float zoomStep;

    public void ZoomIn()
    {
        Debug.Log("here");
        canvas.scaleFactor += zoomStep;
    }

    public void ZoomOut()
    {
        canvas.scaleFactor -= zoomStep;
    }
}
