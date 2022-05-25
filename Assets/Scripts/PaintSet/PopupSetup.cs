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
        popup = GameObject.FindGameObjectsWithTag("Popup")[1];
        popup.SetActive(false);
    }

    public void RevealPopup(string title, string description, Sprite sprite)
    {
        Debug.Log(sprite.name);
        popup.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprite;
        popup.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = title;
        popup.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = description;
        popup.SetActive(true);
    }
}
