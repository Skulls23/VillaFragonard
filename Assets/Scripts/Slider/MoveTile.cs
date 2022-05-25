using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTile : MonoBehaviour
{
    private bool   correctPlace = false;
    private string imageName;
    private float  startPosX;
    private float  startPosY;

    // Start is called before the first frame update
    void Start()
    {
        imageName = GetComponent<Image>().name;
    }

    public void InitMove()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        startPosX = mousePos.x - this.transform.position.x;
        startPosY = mousePos.y - this.transform.position.y;
    }

    public void EndMove()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        float startXMinusNewX = startPosX - mousePos.x;
        float startYMinusNewY = startPosY - mousePos.y;

        if (startXMinusNewX < 0 && startYMinusNewY < 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to right-up but more up than right
            MoveInHierarchy("up");
        else if (startXMinusNewX < 0 && startYMinusNewY < 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to right-up but more right than up
            MoveInHierarchy("right");
        else if (startXMinusNewX < 0 && startYMinusNewY > 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to right-down but more down than right
            MoveInHierarchy("down");
        else if (startXMinusNewX < 0 && startYMinusNewY > 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to right-down but more right than down
            MoveInHierarchy("right");
        else if (startXMinusNewX > 0 && startYMinusNewY < 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to left-up but more up than left
            MoveInHierarchy("up");
        else if (startXMinusNewX > 0 && startYMinusNewY < 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to left-up but more left than up
            MoveInHierarchy("left");
        else if (startXMinusNewX > 0 && startYMinusNewY > 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to left-down but more down than left
            MoveInHierarchy("down");
        else if (startXMinusNewX > 0 && startYMinusNewY > 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to left-down but more left than down
            MoveInHierarchy("left");
        else
            print("static");


    }

    public void Placed()
    {
        if(GameObject.Find("C" + this.gameObject.name).transform == this.transform)
        {
            correctPlace = true;
            print("good");
        }
    }

    private void MoveInHierarchy(string direction)
    {
        if (direction == "up")
            print("U");
        else if (direction == "right")
            print("R");
        else if (direction == "down")
            print("D");
        else if (direction == "left")
            print("L");
    }
}
