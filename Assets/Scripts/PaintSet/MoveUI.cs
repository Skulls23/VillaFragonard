using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allow to move a UI component with Event Triggers
/// </summary>
public class MoveUI : MonoBehaviour
{
    [SerializeField] private float distanceMaxXToBeFinished = 200f;
    [SerializeField] private float distanceMaxYToBeFinished = 80f;
    public GameObject destination;  //Not needed in Visit

    private float xStartingPos;
    private float yStartingPos;

    private void Start()
    {
        xStartingPos = transform.position.x;
        yStartingPos = transform.position.y;
    }

    /// <summary>
    /// Place the clicked <c>GameObject</c> on the mouse position. <br/>
    /// </summary>
    public void InitMove()
    {
        if(GetComponent<Image>().sprite != null)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            destination = GameObject.Find(GetComponent<Image>().sprite.name);
        }

        //gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
    }

    /// <summary>
    /// Move the UI component.
    /// </summary>
    public void Move()
    {
        if (GetComponent<Image>().sprite != null)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            if (GetComponent<Image>() != null && GameObject.Find(GetComponent<Image>().sprite.name).GetComponent<Image>().color.a != 1)
                gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
        }
    }

    /// <summary>
    /// Stop the UI component and validate it. <br/>
    /// <c>PaintSet</c> scene only. <br/>
    /// </summary>
    public void StopMovePaintSet()
    {
        //DEBUG
        //print("X " + Mathf.Abs(transform.position.x - destination.transform.position.x));
        //print("Y " + Mathf.Abs(transform.position.y - destination.transform.position.y));
        if (GetComponent<Image>().sprite != null)
        {
            if (Mathf.Abs(transform.position.x - destination.transform.position.x) <= distanceMaxXToBeFinished &&
                Mathf.Abs(transform.position.y - destination.transform.position.y) <= distanceMaxYToBeFinished || GetComponent<Image>().sprite.name == "3f0525" &&
                Mathf.Abs(transform.position.y - destination.transform.position.y) <= distanceMaxYToBeFinished)
            {
                //transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, transform.position.z);
                transform.position = new Vector3(xStartingPos, yStartingPos, 0);

                transform.gameObject.GetComponent<Image>().sprite = null;
                transform.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                destination.GetComponent<Image>().color = new Color(255, 255, 255, 1);

                GameObject.Find("StuffPositionPanel").GetComponent<CreateObjectWithImage>().ObjectPlaced();
                GameObject.Find("Gameplay").GetComponent<WinCondition>().Verify();
            }
        }
    }

    /// <summary>
    /// Move the UI component in the Visit Scene.
    /// </summary>
    public void MoveVisit()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;

        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
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
        ChangeText ct = GameObject.Find("MoveableText").GetComponent<ChangeText>();

        Vector3 mousePos;
        mousePos = Input.mousePosition;
        
        GameObject[] aSide = GameObject.FindGameObjectsWithTag("Finish");
        float[] aAbsoluteValues = new float[aSide.Length];
        for (int i = 0; i < aSide.Length; i++)
            aAbsoluteValues[i] = Mathf.Abs(Mathf.Abs(mousePos.x) - Mathf.Abs(aSide[i].transform.position.x)) +
                                 Mathf.Abs(Mathf.Abs(mousePos.y) - Mathf.Abs(aSide[i].transform.position.y));

        int sideNumber = 9;
        for (int i = 0; i < aAbsoluteValues.Length; i++)
            if (aAbsoluteValues[i] == Mathf.Min(aAbsoluteValues))
                sideNumber = i;

        switch (aSide[sideNumber].name)
        {
            case "Left":
                if (ct.GetActualDirection().Equals("Left"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
            case "Center":
                if (ct.GetActualDirection().Equals("Center") || ct.GetActualDirection().Equals("Center or Right"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
            case "Right":
                if (ct.GetActualDirection().Equals("Right") || ct.GetActualDirection().Equals("Center or Right"))
                    ct.CorrectAnswer();
                ResetPosition();
                break;
        }
    }

    private void ResetPosition()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, gameObject.transform.position.z);
    }
}
