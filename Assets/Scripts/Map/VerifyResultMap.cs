using System;
using UnityEngine;
using UnityEngine.UI;

public class VerifyResultMap : MonoBehaviour
{
    [Header("This script contains the last text")]
    public bool boolToShowMessage; //It's useless, it's just to show a message
    private string ruleText  = "Déplacer les lettres gagnées pour former le mot mystère." + Environment.NewLine +
                               "Pour consulter à nouveau les indices, double-cliquer sur les lettres.";
    private string rule2Text = "Si besoin d’aide, cliquer sur";
    
    private string endText   = "Bravo !"                                                                                       + Environment.NewLine +
                               "Alexandre-Maubert était franc-maçon."                                                          + Environment.NewLine +
                               "Le décor de cette cage d’escalier est conçu par son cousin Jean-Honoré Fragonard, "            +
                               "il est orné de symboles faisant référence à la Révolution française et à la franc-maçonnerie." + Environment.NewLine +
                               "Vous avez déverrouillé 3 secrets de la Villa :"                                                + Environment.NewLine +
                               "   •  Les symboles de la cage d’escalier"                                                      + Environment.NewLine +
                               "   •  Une sélection d’œuvres sur papier conservées en réserve"                                 + Environment.NewLine +
                               "   •  L’histoire et les visuels du Salon des Copies";
    private GameObject[] aCluesToGuess;
    private bool isFinished;
    private GameObject popup;
    private GameObject popupRule;

    private void Awake()
    {
        popup     = GameObject.Find("PopUpEnd");
        popupRule = GameObject.Find("PopUpRule");
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        
        if (PlayerPrefs.GetInt("Number of clues unlocked") >= PlayerPrefs.GetInt("Number of clues to be unlocked"))
        {
            popupRule.SetActive(true);
            popupRule.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ruleText;
            popupRule.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = rule2Text;
            popupRule.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }
        else
            popupRule.SetActive(false);
        
        aCluesToGuess = GameObject.FindGameObjectsWithTag("ChoicePiece");
        VerifyIfGameAlreadyFinished();
    }

    private void VerifyIfGameAlreadyFinished()
    {
        if (PlayerPrefs.HasKey("Unlock secret") && PlayerPrefs.GetInt("Unlock secret") == 1)
        {
            for (int i = 0; i < aCluesToGuess.Length; i++)
                aCluesToGuess[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Clues/" + aCluesToGuess[i].transform.name);
        }
    }

    public void ChangeMade()
    {
        isFinished = true;
        for (int i = 0; i < aCluesToGuess.Length; i++)
            if (!aCluesToGuess[i].transform.name.Equals(aCluesToGuess[i].GetComponent<Image>().sprite.name))
                isFinished = false;

        if (isFinished)
        {
            PlayerPrefs.SetInt("Unlock secret", 1);
            popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = endText;
            popup.SetActive(true);
        }
    }
}
