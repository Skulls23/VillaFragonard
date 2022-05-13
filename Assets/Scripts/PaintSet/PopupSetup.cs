using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetup : MonoBehaviour
{
    private GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.FindGameObjectsWithTag("Popup")[0];
        popup.SetActive(false);
    }

    public void RevealPopup(string textPopUp, Sprite sprite)
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textPopUp;
        popup.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = sprite;
        popup.SetActive(true);
    }
}
