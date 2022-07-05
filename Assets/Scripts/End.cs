using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private string clueUnlocked;
    [SerializeField] private string popUpText;
    private GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
        popup.SetActive(false);
    }

    public void Win()
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
        popup.SetActive(true);

        PlayerPrefs.SetInt(clueUnlocked, 1);
    }
}
