using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script manage the letter-clues on the Map. <br/>
/// It also manage the pop up of the text-clues.
/// </summary>
public class CluesRevealer : MonoBehaviour
{
    private static string[] aLetter = { "F", "R", "A", "N", "C", "Ç", "M", "O" };
    private GameObject[] aCluesButton;

    private void Awake()
    {
        //If the game is launched for the first time
        if (!PlayerPrefs.HasKey("Number of clues unlocked"))
            PlayerPrefs.SetInt("Number of clues unlocked", 0);
        
        if (!PlayerPrefs.HasKey("Number of clues to be unlocked"))
            PlayerPrefs.SetInt("Number of clues to be unlocked", 8); //TO BE CHANGED IF A GAME IS ADDED;

        if (!PlayerPrefs.HasKey("Previous Number"))
            PlayerPrefs.SetInt("Previous Number", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //UnlockAll();

        
        //We will show the popup when we unlock a new clue letter
        if (PlayerPrefs.GetInt("Number of clues unlocked") > PlayerPrefs.GetInt("Previous Number"))
        {
            PlayerPrefs.SetInt("Previous Number", PlayerPrefs.GetInt("Number of clues unlocked"));
            GameObject.Find("Gameplay").GetComponent<ShowTextClue>().ShowClue(PlayerPrefs.GetInt("Number of clues unlocked") - 1);
        }

        //The button to see again the clue text must disappear
        aCluesButton = new GameObject[aLetter.Length];
        for (int i = 0; i < aLetter.Length; i++)
        {
            aCluesButton[i] = GameObject.Find("Clue Text (" + i + ")");
            aCluesButton[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        
        for (int i = 0; i < PlayerPrefs.GetInt("Number of clues unlocked"); i++)
        {
            
            aCluesButton[i].GetComponent<Image>().color = new Color(255, 255, 255, 1f); //the clue button bound to the clue text again reappear
            for (int j = 0; j < aLetter.Length; j++)
                if (PlayerPrefs.GetInt(aLetter[j]) == i + 1)
                {
                    aCluesButton[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Clues/" + aLetter[j]);
                    aCluesButton[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
                    if(GameObject.Find(aLetter[j] + " collider") != null)
                        GameObject.Find(aLetter[j] + " collider").SetActive(false); //disable the collider bound to that clue
                }
        }
    }

    private void UnlockAll()
    {
        PlayerPrefs.SetInt("A", 1);
        PlayerPrefs.SetInt("N", 2);
        PlayerPrefs.SetInt("C", 3);
        PlayerPrefs.SetInt("R", 4);
        PlayerPrefs.SetInt("M", 5);
        PlayerPrefs.SetInt("F", 6);
        PlayerPrefs.SetInt("O", 7);
        PlayerPrefs.SetInt("Ç", 8);
        PlayerPrefs.SetInt("Number of clues unlocked", 8);
    }
}
