using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMessage : MonoBehaviour
{
    private GameObject popup;
    private string firstMessage = "Bonjour,"                                                                        + Environment.NewLine +
                                  "Bienvenue dans la Villa-Musée Jean-Honoré Fragonard."                            + Environment.NewLine +
                                  "Nous vous invitons à parcourir le musée d’œuvre en œuvre à travers 8 mini-jeux." + Environment.NewLine +
                                  "Vous découvrirez ainsi les secrets du bâtiment et des collections du musée."     + Environment.NewLine +
                                  "A chaque mini-jeu accompli, vous gagnerez une LETTRE et un INDICE qui vous permettront de résoudre l’énigme finale pour accéder aux secrets cachés et codés de la Villa.";


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
