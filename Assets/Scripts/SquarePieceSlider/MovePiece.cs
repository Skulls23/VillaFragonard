using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePiece : MonoBehaviour
{
    private static int MAX_TILE_NUMBER = 20;

    private int    positionInHierarchy;
    private bool   isCorrectlyPlaced = false;

    private float  startPosX;
    private float  startPosY;

    // Start is called before the first frame update
    void Start()
    {
        positionInHierarchy = transform.GetSiblingIndex();
        Moved(); //In case the Piece is already on the good spot
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

        if      (startXMinusNewX <= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //Cursor moved to right-up but more up than right
            MoveInHierarchy("up");
        else if (startXMinusNewX <= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //Cursor moved to right-up but more right than up
            MoveInHierarchy("right");
        else if (startXMinusNewX <= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //Cursor moved to right-down but more down than right
            MoveInHierarchy("down");
        else if (startXMinusNewX <= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //Cursor moved to right-down but more right than down
            MoveInHierarchy("right");
        else if (startXMinusNewX >= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //Cursor moved to left-up but more up than left
            MoveInHierarchy("up");
        else if (startXMinusNewX >= 0 && startYMinusNewY <= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //Cursor moved to left-up but more left than up
            MoveInHierarchy("left");
        else if (startXMinusNewX >= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) < Mathf.Abs(startYMinusNewY)) //Cursor moved to left-down but more down than left
            MoveInHierarchy("down");
        else if (startXMinusNewX >= 0 && startYMinusNewY >= 0 && Mathf.Abs(startXMinusNewX) > Mathf.Abs(startYMinusNewY)) //Cursor moved to left-down but more left than down
            MoveInHierarchy("left");
        else
            print("static");

        //TODO Possible bug when a axis is = 0
    }

    public bool GetIsCorrectlyPlaced()
    {
        return isCorrectlyPlaced;
    }

    private void MoveInHierarchy(string direction)
    {
        positionInHierarchy = transform.GetSiblingIndex();
        Transform movedTile = null; //We will move a Piece. We need to verify it position

        if (direction == "up")
        {
            if (positionInHierarchy > 4) //Can't move up the first 5 first childs 
            {
                movedTile = transform.parent.GetChild(positionInHierarchy - 5);
                movedTile.SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy - 5);
            }
        }
        else if (direction == "right")
        {
            if (positionInHierarchy % 5 != 4) //The pieces on right can't move right
            {
                movedTile = transform.parent.GetChild(positionInHierarchy + 1);
                movedTile.SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy + 1);
            }
        }
        else if (direction == "down")
        {
            if (positionInHierarchy + 5 <= MAX_TILE_NUMBER - 1) //Verify if the future position is in the limit
            {
                movedTile = transform.parent.GetChild(positionInHierarchy + 5);
                movedTile.SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy + 5);
            }
        }
        else if (direction == "left")
        {
            if (positionInHierarchy % 5 != 0) //The pieces on left can't move left
            {
                movedTile = transform.parent.GetChild(positionInHierarchy - 1);
                movedTile.SetSiblingIndex(positionInHierarchy);
                transform.SetSiblingIndex(positionInHierarchy - 1);
            }
        }

        Moved();
        movedTile.GetComponent<MovePiece>().Moved();
    }

    public void Moved()
    {
        positionInHierarchy = transform.GetSiblingIndex();

        if (GameObject.Find("C" + gameObject.name).transform.GetSiblingIndex() == positionInHierarchy)
        {
            isCorrectlyPlaced = true;
            GameObject.Find("Gameplay").GetComponent<PlacementVerifier>().AreAllSliderPiecesCorrect();
        }
        else
            isCorrectlyPlaced = false;
    }
}
