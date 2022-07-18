using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreInfoPopup : MonoBehaviour
{
    [SerializeField] private string textToBeAdded;
    private GameObject plusButton;

    private void Awake()
    {
        plusButton = transform.GetChild(0).Find("MoreInfo").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (textToBeAdded != "")
        {
            plusButton.SetActive(true);
        }
        else
        {
            plusButton.SetActive(false);
        }
    }

    public string TextToBeAdded
    {
        get { return textToBeAdded; }
        set { textToBeAdded = value; }
    }
}
