using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [Header("Lists")]
    [SerializeField] private List<string> lOrderStrings;
    [SerializeField] private List<string> lTextPopUp;

    [SerializeField] private string clueName;

    private GameObject popUp;
    private int missionNumber = 0;

    private void Start()
    {
        popUp = GameObject.Find("PopUp");
        popUp.SetActive(false);
        text.text = lOrderStrings[missionNumber];
    }

    public void ButtonClicked(int numButton)
    {
        if (numButton == missionNumber)
            MissionStepComplete();
    }

    public int GetNumberOfElementToClick()
    {
        return lOrderStrings.Count;
    }

    private void MissionStepComplete()
    {
        PopUp();
        missionNumber++;
        if (lOrderStrings.Count > missionNumber)
            text.text = lOrderStrings[missionNumber];
        else
        {
            text.text = "Niveau fini";
            PlayerPrefs.SetInt(clueName, 1);
        }
            
    }

    private void PopUp()
    {
        if(string.Compare(lTextPopUp[missionNumber], "") != 0)
        {
            popUp.SetActive(true);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = lTextPopUp[missionNumber];
        }
    }
}
