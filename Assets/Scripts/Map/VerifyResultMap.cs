using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyResultMap : MonoBehaviour
{
    [SerializeField] private string endText;
    private GameObject[] aCluesToGuess;
    private bool isFinished;
    private GameObject popup;

    private void Awake()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
    }

    // Start is called before the first frame update
    void Start()
    {
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
        for(int i = 0; i < aCluesToGuess.Length; i++)
            if(! aCluesToGuess[i].transform.name.Equals(aCluesToGuess[i].GetComponent<Image>().sprite.name))
                isFinished = false;

        if (isFinished)
        {
            PlayerPrefs.SetInt("Unlock secret", 1);
            popup.SetActive(true);
            popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = endText;
        }
    }
}
