using UnityEngine;
using UnityEngine.UI;

public class PopupSetup : MonoBehaviour
{
    private GameObject popup;

    void OnGUI()
    {
        GUI.skin.label.wordWrap = true;
    }

    private void Awake()
    {
        popup = GameObject.Find("PopUpInfo");
        if(popup == null)
            popup = GameObject.Find("PopUp");
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    public void RevealPopupInfo(string title, string description, Sprite sprite)
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite         = sprite;
        popup.transform.GetChild(0).GetChild(1).GetComponent<Text>().text            = title;
        popup.transform.GetChild(0).GetChild(2).GetComponent<Text>().text            = description;
        popup.transform.GetChild(0).GetChild(0).GetComponent<Image>().preserveAspect = true;
        popup.SetActive(true);
    }
    
    public void RevealPopup(string description)
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = description;
        popup.SetActive(true);
    }
}