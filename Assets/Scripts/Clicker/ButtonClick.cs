using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] int numButton;

    private Clicker      clicker;
    private ClickerPopUp clickerPopUp;
    private void Start()
    {
        clicker      = GameObject.Find("Gameplay").GetComponent<Clicker>();
        clickerPopUp = GameObject.FindWithTag("Popup").transform.GetChild(0).GetChild(2).GetComponent<ClickerPopUp>();
    }

    public void Clicked()
    {
        clickerPopUp.SetClickerNumber(numButton);
        clicker.GetComponent<Clicker>().ButtonClicked(numButton);
    }
}
