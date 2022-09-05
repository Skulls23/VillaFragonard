using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle all the Lavandiere minigame. <br/>
/// 
/// ALL LIST MUST BE AT THE SAME SIZE!
/// </summary>
public class Clicker : MonoBehaviour
{
    [SerializeField] private Text text;

    [Header("Lists")]
    [SerializeField] private List<string> lOrderStrings;

    [Header("En cas d'apparition de popup lors d'un click")]
    [SerializeField] private List<string> lTextPopUp;
    [SerializeField] private List<Sprite> lSpritePopUp;

    [SerializeField] private string clueName;

    private string txtFinal = "Ce tableau a connu un grand succ�s au 18�me si�cle. Achet� par Louis 18, c�est ma seconde �uvre � int�grer les collections du Mus�e du Louvre."  + Environment.NewLine +
                              "Dans ce paysage, j�ajoute des d�tails qui font r�f�rence aux paysages des peintres Hollandais du 17�me si�cle. La pr�sence des lavandi�res fait" +
                              "passer le tableau d�un genre de peinture � un autre: de paysage � sc�ne de genre.";

    private GameObject popUpWithoutImage;
    private GameObject popUpDetailWithImage;
    private GameObject popUpFinal;
    private int missionNumber = 0;

    private void Start()
    {
        popUpWithoutImage = GameObject.Find("PopUpWithoutImage");
        popUpWithoutImage.SetActive(false);
        popUpDetailWithImage = GameObject.Find("PopUpWithImage");
        popUpDetailWithImage.SetActive(false);
        popUpFinal = GameObject.Find("PopUp");
        popUpFinal.SetActive(false);
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
        missionNumber++;
        PopUp();
        if (lOrderStrings.Count > missionNumber)
            text.text = lOrderStrings[missionNumber];
        else
        {
            text.text = "Niveau fini";
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
        }
            
    }

    private void PopUp()
    {
        if (string.Compare(lTextPopUp[missionNumber-1], "") != 0)
        {
            if (lSpritePopUp[missionNumber - 1] != null)
            {
                popUpDetailWithImage.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = lSpritePopUp[missionNumber - 1];
                popUpDetailWithImage.transform.GetChild(0).GetChild(1).GetComponent<Image>().preserveAspect = true;
                popUpDetailWithImage.transform.GetChild(0).GetChild(0).GetComponent<Text>().text    = lTextPopUp[missionNumber - 1];
                popUpDetailWithImage.SetActive(true);
            }
            else
            {
                popUpWithoutImage.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = lTextPopUp[missionNumber - 1];
                popUpWithoutImage.SetActive(true);
            }
            
            if (missionNumber >= lOrderStrings.Count)
            {
                popUpFinal.SetActive(true);
                popUpFinal.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = txtFinal;
                popUpFinal.GetComponent<MoreInfoPopup>().TextToBeAdded = "Les genres en peinture."     + Environment.NewLine + Environment.NewLine +
                                                                    "Dans la peinture acad�mique, les peintures sont class�es selon les sujets repr�sent�s, du plus noble au moins noble :" + Environment.NewLine +
                                                                    "   1.La peinture d�histoire" + Environment.NewLine +
                                                                    "   2.Le portrait"            + Environment.NewLine +
                                                                    "   3.La sc�ne de genre"      + Environment.NewLine +
                                                                    "   4.Le paysage"             + Environment.NewLine +
                                                                    "   5.La nature morte";
            }
        }
    }
}
