using System;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private string clueName;

    private GameObject[] aPieces;
    private GameObject   popUpEnd;
    private GameObject   popUpRule;
    private bool         isFinished;

    private void Awake()
    {
        aPieces   = GameObject.FindGameObjectsWithTag("Piece");
        popUpEnd  = GameObject.Find("PopUp");
        popUpRule = GameObject.Find("PopUpRule");

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
            popUpEnd.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Cette bo�te � couleurs m�a appartenu. Les flacons contiennent des pigments en poudre de diff�rentes couleurs." + Environment.NewLine +
                                                                                   "Pour faire de la peinture, on m�lange un pigment avec un liant.Selon le type de peinture souhait�, le liant n�est pas le m�me : " +
                                                                                   "un jaune d��uf pour faire de la peinture a tempera, de l�huile de lin pour faire de la peinture � l�huile�";
            popUpEnd.SetActive(true);
            popUpRule.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "La bo�te � couleurs est compl�t�e. Double-cliquer sur un �l�ment pour en savoir plus." + Environment.NewLine +
                                                                                    "Cliquer sur la fl�che du bas pour revenir sur le plan et poursuivre votre parcours.";
            popUpRule.SetActive(true);
        }
    }
}
