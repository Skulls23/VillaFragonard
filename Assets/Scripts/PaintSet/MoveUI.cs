using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allow to move a UI component with Event Triggers
/// </summary>
public class MoveUI : MonoBehaviour
{
    [SerializeField] private float distanceMaxToBeFinished = 80f;
    public bool isFinished;
    private GameObject destination;

    private void Start()
    {
        destination = GameObject.Find(GetComponent<Image>().sprite.name);
    }

    /// <summary>
    /// Place the clicked <c>GameObject</c> on the mouse position. <br/>
    /// </summary>
    public void InitMove()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        //gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
    }

    /// <summary>
    /// Move the UI component.
    /// </summary>
    public void Move()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        if(!isFinished)
            gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
    }

    /// <summary>
    /// Stop the UI component and validate it. <br/>
    /// <c>PaintSet</c> scene only. <br/>
    /// </summary>
    public void StopMovePaintSet()
    {
        if (Mathf.Abs(transform.position.x - destination.transform.position.x) <= distanceMaxToBeFinished &&
            Mathf.Abs(transform.position.y - destination.transform.position.y) <= distanceMaxToBeFinished)
        {
            transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, transform.position.z);
            isFinished = true;
            GameObject.Find("StuffPositionPanel").GetComponent<CreateObjectWithImage>().ObjectPlaced();
            GameObject.Find("Gameplay").GetComponent<WinCondition>().Verify();
        }
        else
            isFinished = false;
    }

    /// <summary>
    /// Stop the UI component and validate it. <br/>
    /// <c>Visit</c> scene only. <br/> <br/>
    /// 
    /// The purpose of that method is to know on which side the text in Visit's Scene as been move, with that we know what is the answer of the user. <br/>
    /// <c>
    /// |A.x| - |B.x| = C.x <br/>
    /// |A.y| - |B.y| = C.y <br/>
    /// |C.x| + |C.y| = D <br/>
    /// </c>
    /// The lowest value of D indicate the side the mouse is the closest. <br/>
    /// </summary>
    public void StopMoveVisit()
    {
        ChangeText ct = GameObject.Find("Text").GetComponent<ChangeText>();

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

        print(ct.GetActualDirection());

        switch (aSide[sideNumber].name)
        {
            case "Left":
                if (ct.GetActualDirection().Equals("Left"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
            case "Center":
                if (ct.GetActualDirection().Equals("Center"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
            case "Right":
                if (ct.GetActualDirection().Equals("Right"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
        }

        if (ct.GetActualDirection().Equals("END"))
            print("POPUP here");
    }

    private void ResetPosition()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, gameObject.transform.position.z);
    }

    public bool GetIsFinished()
    {
        return isFinished;
    }
}
