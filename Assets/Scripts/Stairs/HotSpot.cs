using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    [SerializeField] private string     message;
    [SerializeField] private PopupSetup popupSetup;

    public void Clicked()
    {
        popupSetup.RevealPopup(message);
    }
}
