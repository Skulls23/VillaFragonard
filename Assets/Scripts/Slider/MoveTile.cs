using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTile : MonoBehaviour
{
    private static int MAX_TILE_NUMBER = 20;

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

        startPosX = mousePos.x;
        startPosY = mousePos.y;
    }

    public void EndMove()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        float startXMinusNewX = Mathf.Abs(startPosX) - Mathf.Abs(mousePos.x);
        float startYMinusNewY = Mathf.Abs(startPosY) - Mathf.Abs(mousePos.y);

        if      (startXMinusNewX <= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to right-up but more up than right
            MoveInHierarchy("up");
        else if (startXMinusNewX <= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to right-up but more right than up
            MoveInHierarchy("right");
        else if (startXMinusNewX <= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to right-down but more down than right
            MoveInHierarchy("down");
        else if (startXMinusNewX <= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to right-down but more right than down
            MoveInHierarchy("right");
        else if (startXMinusNewX >= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to left-up but more up than left
            MoveInHierarchy("up");
        else if (startXMinusNewX >= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to left-up but more left than up
            MoveInHierarchy("left");
        else if (startXMinusNewX >= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //cursor moved to left-down but more down than left
            MoveInHierarchy("down");
        else if (startXMinusNewX >= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //cursor moved to left-down but more left than down
            MoveInHierarchy("left");
        else
            print("static");

        //TODO Possible bug when something = 0
    }

    public void Placed()
    {
        if (GameObject.Find("C" + gameObject.name).transform == transform)
        {
            correctPlace = true;
            print("good");
        }
    }

    private void MoveInHierarchy(string direction)
    {
        print(direction);
        int positionInHierarchy = transform.GetSiblingIndex();

        if (direction == "up")
        {
            if (positionInHierarchy >= 0)
            {
                transform.parent.GetChild(positionInHierarchy - 5).SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy - 5);
            }
        }
        else if (direction == "right")
        {
            if (positionInHierarchy + 1 <= MAX_TILE_NUMBER - 1)
            {
                transform.parent.GetChild(positionInHierarchy + 1).SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy + 1);
            }
        }
        else if (direction == "down")
        {
            if (positionInHierarchy + 5 <= MAX_TILE_NUMBER - 1)
            {
                transform.parent.GetChild(positionInHierarchy + 5).SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy + 5);
            }
        }
        else if (direction == "left")
        {
            if (positionInHierarchy - 1 >= 0)
            {
                transform.parent.GetChild(positionInHierarchy - 1).SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy - 1);
            }
        }
    }
}
