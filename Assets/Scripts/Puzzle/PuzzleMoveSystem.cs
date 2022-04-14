using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoveSystem : MonoBehaviour
{
    private GameObject correctForm;
    private bool moving;
    private bool isFinished = false;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        correctForm = GameObject.Find("c" + this.name);
        resetPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) <= 0.5f &&
           Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, this.transform.position.z);
            isFinished = true;
        }
        else
            isFinished = false;
    }
    public bool GetIsFinished()
    {
        return isFinished;
    }
}
