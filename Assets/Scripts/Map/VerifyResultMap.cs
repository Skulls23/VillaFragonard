using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyResultMap : MonoBehaviour
{
    private GameObject[] aCluesToGuess;
    private bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        aCluesToGuess = GameObject.FindGameObjectsWithTag("ChoicePiece");
    }

    public void ChangeMade()
    {
        isFinished = true;
        for(int i = 0; i < aCluesToGuess.Length; i++)
        {
            if(! aCluesToGuess[i].transform.name.Equals(aCluesToGuess[i].GetComponent<Image>().sprite.name))
                isFinished = false;
        }

        if(isFinished)
        {
            print("End");
            PlayerPrefs.SetInt("Unlock secret", 1);
        }
    }
}
