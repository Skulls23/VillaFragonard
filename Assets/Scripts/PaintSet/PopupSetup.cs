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
        popup.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprite;
        popup.transform.GetChild(0).GetChild(1).GetComponent<Text>().text    = title;
        popup.transform.GetChild(0).GetChild(2).GetComponent<Text>().text    = description;
        popup.SetActive(true);
    }
}