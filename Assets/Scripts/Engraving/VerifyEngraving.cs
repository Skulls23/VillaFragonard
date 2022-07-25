using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyEngraving : MonoBehaviour
{
    [SerializeField] private int numberToWin = 3;
    [SerializeField] private string clueName;
    private int numCorrect;
    
    public void VerifySprites()
    {

        GameObject[] go = GameObject.FindGameObjectsWithTag("Piece");


        if (go[0].GetComponent<Image>().sprite.name == go[1].GetComponent<Image>().sprite.name)// + "Print")
        {
            numCorrect++;
            go[0].GetComponent<Swap>().DeleteActualSprite();
            go[1].GetComponent<Swap>().DeleteActualSprite();
        }
        print(numCorrect + " " + numberToWin);
        if (numCorrect == numberToWin)
        {
            print("win");
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
        }
    }
}
