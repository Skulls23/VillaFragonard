using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private List<string>     lOrdersString;
    [SerializeField] private List<GameObject> lOrdersCollider;

    private int missionNumber = 0;

    private void Start()
    {
       /* lOrdersString = new List<string>();
        lOrdersString.Add("Trouve le tricorne");
        lOrdersString.Add("Trouve la chaussure volante");
        lOrdersString.Add("Trouve l'ètre apeuré");

        lOrdersCollider = new List<GameObject>();
        lOrdersCollider.Add(GameObject.Find("Tricorn"));
        lOrdersCollider.Add(GameObject.Find("Shoe"));
        lOrdersCollider.Add(GameObject.Find("Kid Head"));*/

        text.text = lOrdersString[missionNumber];
    }

    private void Update()
    {
        MouseListener();
    }

    private void MouseListener()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetType() == typeof(BoxCollider2D) && hit.collider.transform.gameObject.name == lOrdersCollider[missionNumber].name)
                {
                    missionStepComplete();
                }
            }
        }
    }

    private void missionStepComplete()
    {
        missionNumber++;
        if (lOrdersCollider.Count > missionNumber)
            text.text = lOrdersString[missionNumber];
        else
            text.text = "niveau fini";
    }
}
