using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Verify the placement of a <c>Piece</c>.
/// </summary>
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
            if (!lPieces[i].GetComponent<MovePiece>().GetIsCorrectlyPlaced())
                isCompletelyFinished = false;

        if (isCompletelyFinished)
        {
            PlayerPrefs.SetInt(clueName, 1);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
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
        {
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
        }
    }
}
