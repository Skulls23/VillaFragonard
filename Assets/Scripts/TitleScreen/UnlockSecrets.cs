using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecrets : MonoBehaviour
{
    private GameObject stairsButton;
    private GameObject reserveButton;
    private GameObject copiesButton;

    // Start is called before the first frame update
    void Start()
    {
        stairsButton  = GameObject.Find("Stairs");
        reserveButton = GameObject.Find("Reserve");
        copiesButton  = GameObject.Find("Copies");

        if (PlayerPrefs.HasKey("Unlock secret") && PlayerPrefs.GetInt("Unlock secret") == 1)
        {
            stairsButton.SetActive (true);
            reserveButton.SetActive(true);
            copiesButton.SetActive (true);
        }
        else
        {
            stairsButton.SetActive (false);
            reserveButton.SetActive(false);
            copiesButton.SetActive (false);
        }
    }
}
