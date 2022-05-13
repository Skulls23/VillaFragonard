using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    private float startPosX;
    private float startPosY;


    public void InitMove()
    {
        Debug.Log("1");
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        startPosX = mousePos.x - this.transform.position.x;
        startPosY = mousePos.y - this.transform.position.y;
    }

    public void Move()
    {
        Debug.Log("2");
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
    }
}
