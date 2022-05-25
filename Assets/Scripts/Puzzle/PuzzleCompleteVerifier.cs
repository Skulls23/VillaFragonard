using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleCompleteVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lPieces;
    [SerializeField] private float timeToWaitBeforeSceneSwitch;
    [SerializeField] private string clueName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && AreAllPiecesCorrect())
                StartCoroutine(WaitToChangeScene());
    }

    private bool AreAllPiecesCorrect()
    {
        bool isCompletelyFinished = true;

        for(int i = 0; i < lPieces.Count && isCompletelyFinished; i++)
            if(!lPieces[i].GetComponent<PuzzleMoveSystem>().GetIsFinished())
                isCompletelyFinished = false;

        return isCompletelyFinished;
    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(timeToWaitBeforeSceneSwitch);
        PlayerPrefs.SetInt(clueName, 1);
        SceneManager.LoadScene(sceneName: "Map");
    }
}
