using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    [SerializeField] private string letterToUnlock;

    // Start is called before the first frame update
    void Start()
    {
        VerifyColor();
    }

    public void UnlockLetter()
    {
        if (!PlayerPrefs.HasKey(letterToUnlock))
        {
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(letterToUnlock, PlayerPrefs.GetInt("Number of clues unlocked"));
        }
        VerifyColor();
    }
    
    private void VerifyColor()
    {
        if(! PlayerPrefs.HasKey(letterToUnlock))
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            Color color;
            ColorUtility.TryParseHtmlString("#4F932B", out color);
            GetComponent<Image>().color = color;
        }
    }
}
