using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 StopPos;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        print(mousePos);
    }

    public void StartClick()
    {
        startPos = Input.mousePosition;
    }

    public void StopClick()
    {
        StopPos = Input.mousePosition;

        DrawLine(startPos, StopPos, Color.blue);
    }

    private void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor   = color;
        lr.startWidth = 10f;
        lr.endWidth   = 10f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.positionCount = 2;
        lr.sortingOrder = 1;
    }
}
