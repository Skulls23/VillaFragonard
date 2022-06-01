using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlacementVerifier : MonoBehaviour
{
    [SerializeField] private string clueName;
    [SerializeField] private string popUpText;

    private GameObject[] lPieces;
    private GameObject   popUp;

    private void Start()
    {
        lPieces = GameObject.FindGameObjectsWithTag("Piece");
        popUp = GameObject.FindGameObjectWithTag("Popup");
        popUp.SetActive(false);
    }

    public void AreAllSliderPiecesCorrect()
    {
        bool isCompletelyFinished = true;

        for (int i = 0; i < lPieces.Length && isCompletelyFinished; i++)
            if (!lPieces[i].GetComponent<MoveTile>().GetIsCorrectlyPlaced())
                isCompletelyFinished = false;

        if (isCompletelyFinished)
        {
            PlayerPrefs.SetInt(clueName, 1);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = popUpText;
            popUp.SetActive(true);
        }
    }

    public void AreAllPuzzlePiecesCorrect()
    {
        bool isCompletelyFinished = true;

        for (int i = 0; i < lPieces.Length && isCompletelyFinished; i++)
            if (!lPieces[i].GetComponent<PuzzleMoveSystem>().GetIsFinished())
                isCompletelyFinished = false;

        if (isCompletelyFinished)
            PlayerPrefs.SetInt(clueName, 1);
    }
}
