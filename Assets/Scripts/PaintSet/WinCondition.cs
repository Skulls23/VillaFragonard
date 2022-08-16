using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private string clueName;

    private GameObject[] aPieces;
    private GameObject   popUpEnd;
    private bool         isFinished;

    private void Awake()
    {
        aPieces = GameObject.FindGameObjectsWithTag("Piece");
        popUpEnd = GameObject.FindGameObjectsWithTag("Popup")[0];
    }

    void Start()
    {
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

        if (isFinished)
        {
            PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
            PlayerPrefs.SetInt(clueName, PlayerPrefs.GetInt("Number of clues unlocked"));
            popUpEnd.SetActive(true);
        }
    }
}
