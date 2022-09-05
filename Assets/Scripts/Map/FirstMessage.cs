using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMessage : MonoBehaviour
{
    private GameObject popup;

    private string firstMessage = "Bienvenue dans la Villa-Mus�e Jean-Honor� Fragonard."                        + Environment.NewLine +
                                  "Je suis Jean-Honor� Fragonard."                                              + Environment.NewLine +
                                  "Je vous invite � parcourir le mus�e d��uvre en �uvre � travers 8 mini-jeux." + Environment.NewLine +
                                  "Vous d�couvrirez ainsi les secrets du b�timent et des collections du mus�e." + Environment.NewLine +
                                  "A chaque mini-jeu accompli, vous gagnerez une LETTRE et un INDICE qui vous permettront de r�soudre l��nigme finale pour acc�der aux secrets cach�s et cod�s de la Villa.";

    private string firstRule = "Ce plan de l��tage repr�sente les trois salles de la Villa-mus�e." + Environment.NewLine +
                               "Les rectangles gris indiquent les �uvres de votre parcours."       + Environment.NewLine +
                               "Cliquer sur le rectangle de l��uvre pour jouer au mini-jeu correspondant.";
    




    private void Awake()
    {
        popup = GameObject.Find("PopUp");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("First launch"))
        {
            popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = firstMessage;
            popup.GetComponent<MoreInfoPopup>().TextToBeAdded = firstRule;
            popup.SetActive(true);
            PlayerPrefs.SetInt("First launch", 0);
        }
        else
        {
            popup.SetActive(false);
        }
    }
}
