using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplaceButton : MonoBehaviour
{
    private GameObject buttonToDisappear;
    private GameObject buttonToAppear;

    private void Awake()
    {
        buttonToDisappear = GameObject.Find("ReturnMap");
        buttonToAppear    = GameObject.Find("ReturnMapAtEnd");
        
    }

    private void Start()
    {
        buttonToAppear.SetActive(false);
    }


    public void ChangePlace()
    {
        buttonToDisappear.SetActive(false);
        buttonToAppear.SetActive(true);
    }
}
