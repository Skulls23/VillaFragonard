using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] int numButton;

    GameObject clickerScriptContainer;
    private void Start()
    {
        clickerScriptContainer = GameObject.Find("Gameplay");
    }

    public void Clicked()
    {
        if (clickerScriptContainer != null)
            clickerScriptContainer.GetComponent<Clicker>().ButtonClicked(numButton);
    }
}
