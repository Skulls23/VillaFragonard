using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpHandler : MonoBehaviour
{
    private GameObject popup;
    public string message = "Alexandre Maubert appartient à une société secrète. Il est …";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Number of clues unlocked") && PlayerPrefs.GetInt("Number of clues unlocked") == PlayerPrefs.GetInt("Number of clues to be unlocked"))
        {
            gameObject.SetActive(false);
        }
        else
            gameObject.SetActive(true);
    }
    private void Awake()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
    }


    public void Clicked()
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = message;
        popup.SetActive(true);
    }
}
