using System.Collections;
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
        popUp = GameObject.Find("PopUp");
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
            for(int i=0; i < lPieces.Length; i++)
                lPieces[i].GetComponent<MovePiece>().IsFinished = true;
            StartCoroutine(WaitToLeave(2f));
        }
    }


    IEnumerator WaitToLeave(float time)
    {
        yield return new WaitForSeconds(time);
        popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
        popUp.SetActive(true);
        PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
        PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
    }

}
