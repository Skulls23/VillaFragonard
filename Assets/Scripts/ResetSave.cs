using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSave : MonoBehaviour
{
    private GameObject stairsButton;
    private GameObject reserveButton;

    private void Awake()
    {
        stairsButton = GameObject.Find("Stairs");
        reserveButton = GameObject.Find("Reserve");
    }

    public void Reset()
    {
        stairsButton.SetActive(false);
        reserveButton.SetActive(false);
        PlayerPrefs.DeleteAll();
    }
}
