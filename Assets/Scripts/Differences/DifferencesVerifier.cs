using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lImagesParent = new List<GameObject>();
    [SerializeField] private float timeToWaitBeforeSceneSwitch;
    [SerializeField] private string clueName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            for (int i = 0; i < lImagesParent.Count && AreAllDiffFound(); i++)
                    StartCoroutine(WaitToChangeScene());
    }

    private bool AreAllDiffFound()
    {
        
        bool isCompletelyFinished = true;

        for (int i = 0; i < lImagesParent.Count && isCompletelyFinished; i++)
            if (lImagesParent[i].transform.GetChild(0).gameObject.activeSelf)
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
