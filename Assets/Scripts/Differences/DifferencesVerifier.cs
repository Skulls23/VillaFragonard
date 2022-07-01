using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lImagesParent = new List<GameObject>();
    [SerializeField] private string clueName;
    [SerializeField] private string popUpText;

    private GameObject popUp;

    private void Start()
    {
        popUp = GameObject.FindWithTag("Popup");
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            for (int i = 0; i < lImagesParent.Count && AreAllDiffFound(); i++)
            {
                PlayerPrefs.SetInt(clueName, 1);
                popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
                popUp.SetActive(true);
            }
    }

    private bool AreAllDiffFound()
    {
        bool isCompletelyFinished = true;

        for (int i = 0; i < lImagesParent.Count && isCompletelyFinished; i++)
            if (lImagesParent[i].transform.GetChild(0).gameObject.activeSelf)
                isCompletelyFinished = false;
        
        return isCompletelyFinished;
    }
}
