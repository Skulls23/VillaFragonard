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

    public void InitMove()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        startPosX = mousePos.x - this.transform.position.x;
        startPosY = mousePos.y - this.transform.position.y;
    }

    public void Move()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
    }

    public void StopMovePaintSet()
    {
        if (Mathf.Abs(this.transform.position.x - destination.transform.position.x) <= distanceMaxToBeFinished &&
            Mathf.Abs(this.transform.position.y - destination.transform.position.y) <= distanceMaxToBeFinished)
        {
            this.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, this.transform.position.z);
            isFinished = true;
            GameObject.Find("Gameplay").GetComponent<WinCondition>().Verify();
        }
        else
            isFinished = false;
    }

    public void StopMoveVisit()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        
        GameObject[] aSide = GameObject.FindGameObjectsWithTag("Finish");
        float[] aAbsoluteValues = new float[aSide.Length];
        for (int i = 0; i < aSide.Length; i++)
        {
            print(i);
            print(Mathf.Abs(mousePos.x) + " - " + Mathf.Abs(aSide[i].transform.position.x) + " = " + (Mathf.Abs(mousePos.x) - Mathf.Abs(aSide[i].transform.position.x)));
            print(Mathf.Abs(mousePos.y) + " - " + Mathf.Abs(aSide[i].transform.position.y) + " = " + (Mathf.Abs(mousePos.y) - Mathf.Abs(aSide[i].transform.position.y)));
            print(Mathf.Abs(mousePos.x) - Mathf.Abs(aSide[i].transform.position.x) +
                  Mathf.Abs(mousePos.y) - Mathf.Abs(aSide[i].transform.position.y));
            aAbsoluteValues[i] = Mathf.Abs(Mathf.Abs(mousePos.x) - Mathf.Abs(aSide[i].transform.position.x)) +
                                 Mathf.Abs(Mathf.Abs(mousePos.y) - Mathf.Abs(aSide[i].transform.position.y));
        }

        int sideNumber = 9;
        for(int i = 0; i < aAbsoluteValues.Length; i++)
        {
            if (aAbsoluteValues[i] == Mathf.Min(aAbsoluteValues))
                sideNumber = i;
        }
        print(sideNumber);
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
