using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMessage : MonoBehaviour
{
    private GameObject popup;
    private string firstMessage = "Bonjour,"                                                                        + Environment.NewLine +
                                  "Bienvenue dans la Villa-Mus�e Jean-Honor� Fragonard."                            + Environment.NewLine +
                                  "Nous vous invitons � parcourir le mus�e d��uvre en �uvre � travers 8 mini-jeux." + Environment.NewLine +
                                  "Vous d�couvrirez ainsi les secrets du b�timent et des collections du mus�e."     + Environment.NewLine +
                                  "A chaque mini-jeu accompli, vous gagnerez une LETTRE et un INDICE qui vous permettront de r�soudre l��nigme finale pour acc�der aux secrets cach�s et cod�s de la Villa.";


    private void Awake()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("First launch"))
        {
            popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = firstMessage;
            popup.SetActive(true);
            PlayerPrefs.SetInt("First launch", 0);
        }
    }
}
