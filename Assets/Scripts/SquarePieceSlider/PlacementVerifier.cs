using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementVerifier : MonoBehaviour
{
    [SerializeField] private string clueName;

    private GameObject[] lPieces;

    private void Start()
    {
        lPieces = GameObject.FindGameObjectsWithTag("Piece");
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
