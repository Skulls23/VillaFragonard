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

    public void StopMove()
    {
        Debug.Log(this.transform.position.x + " - " + this.transform.position.y + " | " + destination.transform.position.x + " - " + destination.transform.position.y);
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
    public bool GetIsFinished()
    {
        return isFinished;
    }
}
