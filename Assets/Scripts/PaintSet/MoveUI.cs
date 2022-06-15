using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUI : MonoBehaviour
{
    [SerializeField] private float distanceMaxToBeFinished = 80f;
    private float      startPosX;
    private float      startPosY;
    private GameObject destination;
    public  bool       isFinished;

    private void Start()
    {
        destination = GameObject.Find(GetComponent<Image>().sprite.name);
    }

    public void InitMovePaintSet()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        startPosX = mousePos.x - transform.position.x;
        startPosY = mousePos.y - transform.position.y;
    }

    public void InitMoveVisit()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        gameObject.transform.position = new Vector3( mousePos.x, mousePos.y, gameObject.transform.position.z);
    }

    public void Move()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
    }

    public void StopMovePaintSet()
    {
        if (Mathf.Abs(transform.position.x - destination.transform.position.x) <= distanceMaxToBeFinished &&
            Mathf.Abs(transform.position.y - destination.transform.position.y) <= distanceMaxToBeFinished)
        {
            transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, transform.position.z);
            isFinished = true;
            GameObject.Find("Gameplay").GetComponent<WinCondition>().Verify();
        }
        else
            isFinished = false;
    }

    /// <summary>
    /// The purpose of that method is to know on which side the text in Visit's Scene as been move, with that we know what is the answer of the user
    /// |A.x| - |B.x| = C.x
    /// |A.y| - |B.y| = C.y
    /// |C.x| + |C.y| = D
    /// The lowest value of D indicate the side the mouse is the closest
    /// </summary>
    public void StopMoveVisit()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        
        GameObject[] aSide = GameObject.FindGameObjectsWithTag("Finish");
        float[] aAbsoluteValues = new float[aSide.Length];
        for (int i = 0; i < aSide.Length; i++)
            aAbsoluteValues[i] = Mathf.Abs(Mathf.Abs(mousePos.x) - Mathf.Abs(aSide[i].transform.position.x)) +
                                 Mathf.Abs(Mathf.Abs(mousePos.y) - Mathf.Abs(aSide[i].transform.position.y));

        int sideNumber = 9;
        for(int i = 0; i < aAbsoluteValues.Length; i++)
            if (aAbsoluteValues[i] == Mathf.Min(aAbsoluteValues))
                sideNumber = i;

        switch (aSide[sideNumber].name)
        {
            case "Left":
                print("Gauche");
                break;
            case "Center":
                print("Centre");
                break;
            case "Right":
                print("Droite");
                break;
        }
    }

    public bool GetIsFinished()
    {
        return isFinished;
    }
}
