using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private string clueName;

    private GameObject[] aPieces;
    private GameObject   popUpEnd;
    private bool         isFinished;

        void Start()
        {
            aPieces = GameObject.FindGameObjectsWithTag("Piece");

            popUpEnd = GameObject.FindGameObjectsWithTag("Popup")[0];
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

        if(isFinished)
        {
            PlayerPrefs.SetInt(clueName, 1);
            popUpEnd.SetActive(true);
        }
    }
}
