using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lImagesParent = new List<GameObject>();
    [SerializeField] private string clueName;
    private string popUpText = "Au 18�me si�cle, l�imp�ratrice Marie-Th�r�se a r�gn� 40 ans sur l�empire d�Autriche-Hongrie. Elle pr�sente ici son fils Joseph aux Hongrois." + Environment.NewLine + 
                               "Les attitudes, le r�alisme des visages et les d�tails pr�cis rappellent l��uvre de Jacques-Louis David, le ma�tre de mon fils, "              + 
                               "Alexandre-Evariste Fragonard. La p�nombre dans laquelle est plac�e la foule rappelle �galement mon influence.";

    private static string[] lTexts = new string[4]{ "Trouver les 4 diff�rences", "Trouver les 3 diff�rences restantes", "Trouver les 2 diff�rences restantes", "Trouver la diff�rence restante" };
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
