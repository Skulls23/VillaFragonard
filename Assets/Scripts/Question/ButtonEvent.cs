using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private bool isTrue;
    [SerializeField] private string textPopUp;
    [SerializeField] private string clueName;

    private Color baseColor;
    private GameObject popUp;


    private void Start()
    {
        //do it only once, because pop up will disappear for others buttons
        if(isTrue)
        {
            popUp = GameObject.Find("Canvas/PopUp");
            popUp.SetActive(false);
        }
        baseColor = transform.GetComponent<Image>().color;
    }

    public void Answer()
    {
        if(isTrue)
        {
            transform.GetComponent<Image>().color = Color.green;
            PlayerPrefs.SetInt(clueName, 1);
            PopUp();
        }
        else
        {
            transform.GetComponent<Image>().color = Color.red;
            StartCoroutine(ReturnColorToNormal(0.8f));
        }
    }

    IEnumerator ReturnColorToNormal(float f)
    {
        yield return new WaitForSeconds(f);
        transform.GetComponent<Image>().color = baseColor;
    }
    private void PopUp()
    {
            popUp.SetActive(true);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textPopUp;
    }
}
