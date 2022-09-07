using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lImagesParent = new List<GameObject>();
    [SerializeField] private string clueName;
    private string popUpText = "Au 18ème siècle, l’impératrice Marie-Thérèse a régné 40 ans sur l’empire d’Autriche-Hongrie. Elle présente ici son fils Joseph aux Hongrois." + Environment.NewLine + 
                               "Les attitudes, le réalisme des visages et les détails précis rappellent l’œuvre de Jacques-Louis David, le maître de mon fils, "              + 
                               "Alexandre-Evariste Fragonard. La pénombre dans laquelle est placée la foule rappelle également mon influence.";

    private static string[] lTexts = new string[7]{ "Trouver les 7 différences", "Trouver les 6 différences", "Trouver les 5 différences", "Trouver les 4 différences",
                                                    "Trouver les 3 différences restantes", "Trouver les 2 différences restantes", "Trouver la différence restante" };
    private int             errorFound = 0;
    private GameObject      popUp;

    private void Start()
    {
        popUp = GameObject.FindWithTag("Popup");
        popUp.SetActive(false);
        ChangeText();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && AreAllDiffFound() && popUp.activeSelf == false)
        {
            popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
            popUp.SetActive(true);
            GiveClue();
        }
    }
    
    public void IncrementErrorFound()
    {
        errorFound++;
        ChangeText();
    }

    private void ChangeText()
    {
        if(errorFound < lImagesParent.Count)
            GameObject.Find("Rules").GetComponent<Text>().text = lTexts[errorFound];
    }
    
    private bool AreAllDiffFound()
    {
        bool isCompletelyFinished = true;

        for (int i = 0; i < lImagesParent.Count && isCompletelyFinished; i++)
            if (lImagesParent[i].transform.GetChild(0).gameObject.activeSelf)
                isCompletelyFinished = false;


        return isCompletelyFinished;
    }
    
    private void GiveClue()
    {
        PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
        PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
    }
}
