using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Text text;

    [Header("Lists")]
    [SerializeField] private List<string> lOrderStrings;
    [SerializeField] private List<string> lTextPopUp;

    [SerializeField] private string clueName;

    private GameObject popUp;
    private int missionNumber = 0;

    private void Start()
    {
        popUp = GameObject.Find("PopUp");
        popUp.SetActive(false);
        text.text = lOrderStrings[missionNumber];

        lTextPopUp[4] = "Ce tableau a connu un grand succès au 18ème siècle. Acheté par Louis 18, c’est la seconde œuvre de Jean-Honoré Fragonard à intégrer les collections du Musée du Louvre." + Environment.NewLine +
                        "Dans ce paysage, Fragonard ajoute des détails qui font référence aux paysages des peintres Hollandais du 17ème siècle. La présence des lavandières fait passer le tableau d’un genre de peinture à un autre : de paysage à scène de genre.";
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
        PopUp();
        missionNumber++;
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
        if (string.Compare(lTextPopUp[missionNumber], "") != 0)
        {
            popUp.SetActive(true);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = lTextPopUp[missionNumber];
            if (missionNumber == 4)
            {
                popUp.GetComponent<MoreInfoPopup>().TextToBeAdded = "Les genres en peinture."     + Environment.NewLine +
                                                                    "Dans la peinture académique, les peintures sont classées selon les sujets représentés, du plus noble au moins noble :" + Environment.NewLine +
                                                                    "   1.La peinture d’histoire" + Environment.NewLine +
                                                                    "   2.Le portrait"            + Environment.NewLine +
                                                                    "   3.La scène de genre"      + Environment.NewLine +
                                                                    "   4.Le paysage"             + Environment.NewLine +
                                                                    "   5.La nature morte";
            }
        }
    }
}
