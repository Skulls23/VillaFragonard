using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopup : MonoBehaviour
{
    private GameObject popup;

    private void Awake()
    {
        popup = GameObject.Find("PopUpRule");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("WarningShowed"))
        {
            popup.SetActive(true);
            PlayerPrefs.SetInt("WarningShowed", 1);
        }
        else
            popup.SetActive(false);
            
    }
}
