using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script manage the letter-clues on the Map. <br/>
/// It also manage the pop up of the text-clues.
/// </summary>
public class CluesRevealer : MonoBehaviour
{
    private static int NUMBER_OF_CLUES_TO_FIND = 7;

    [SerializeField] private List<GameObject> lClues = new List<GameObject>();
    private int numberOfCluesRevealed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //If the game is launched for the first time
        if (PlayerPrefs.HasKey("Number of clues unlocked") == false)
        {
            PlayerPrefs.SetInt("Number of clues unlocked", 0);
        }

        for (int i = 0; i < lClues.Count; i++)
            if (PlayerPrefs.HasKey(lClues[i].name) && PlayerPrefs.GetInt(lClues[i].name) == 1)
            {
                lClues[i].SetActive(true);
                numberOfCluesRevealed++;
            }
            else
                lClues[i].SetActive(false);

        //If we unlocked a new clues since the last Map loading
        if (PlayerPrefs.GetInt("Number of clues unlocked") < numberOfCluesRevealed)
        {
            GetComponent<ShowTextClue>().ShowClue(numberOfCluesRevealed - 1); //-1 because the first clue is the number 0 in the array
            PlayerPrefs.SetInt("Number of clues unlocked", numberOfCluesRevealed);
        }

        if(numberOfCluesRevealed >= 7)
            PlayerPrefs.SetInt("-", 1);

        for (int i = 0; i < lClues.Count; i++)
            if (lClues[i].name.Equals("-"))
                lClues[i].SetActive(true);
    }
}
