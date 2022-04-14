using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleCompleteVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> pieces;
    [SerializeField] private float timeToWaitBeforeSceneSwitch;
    [SerializeField] private string clueName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            if (AreAllPiecesCorrect())
                StartCoroutine(WaitToChangeScene());

    }

    private bool AreAllPiecesCorrect()
    {
        bool isCompletelyFinished = true;

        for(int i = 0; i < pieces.Count && isCompletelyFinished; i++)
            if(!pieces[i].GetComponent<PuzzleMoveSystem>().GetIsFinished())
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
