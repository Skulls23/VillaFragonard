using System;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private string clueName;

    private GameObject[] aPieces;
    private GameObject   popUpEnd;
    private bool         isFinished;

    private void Awake()
    {
        aPieces = GameObject.FindGameObjectsWithTag("Piece");
        popUpEnd = GameObject.Find("PopUp");
    }

    void Start()
    {
        popUpEnd.SetActive(false);
    }

    public void Verify()
    {
        isFinished = true;
        for (int i = 0; i < aPieces.Length; i++)
        {
            if(aPieces[i].GetComponent<Image>().color.a != 1)
                isFinished = false;
        }

        if (isFinished)
        {
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
            popUpEnd.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Cette boîte à couleurs a sans doute appartenu à Jean - Honoré Fragonard.Les flacons contiennent des pigments en poudre de différentes couleurs." + Environment.NewLine +
                                                                                   "Pour faire de la peinture, on mélange un pigment avec un liant.Selon le type de peinture souhaité, le liant n’est pas le même : un jaune d’œuf pour faire de la peinture a tempera, de l’huile de lin pour faire de la peinture à l’huile…";
;
            popUpEnd.SetActive(true);
        }
    }
}
