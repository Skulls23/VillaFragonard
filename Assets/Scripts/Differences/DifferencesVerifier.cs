using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lImagesParent = new List<GameObject>();
    [SerializeField] private string clueName;
    [SerializeField] private string popUpText;

    private static string[] lTexts = new string[4]{ "Trouve les 4 indices", "Trouve les 3 indices", "Trouve les 2 indices", "Trouve le dernier indice"};
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
        if (Input.GetMouseButtonUp(0))
            for (int i = 0; i < lImagesParent.Count && AreAllDiffFound(); i++)
            {
                PlayerPrefs.SetInt(clueName, 1);
                popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
                popUp.SetActive(true);
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
}
