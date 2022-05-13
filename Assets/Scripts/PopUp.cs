using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public void ClosePopUp()
    {
        GameObject.FindGameObjectWithTag("Popup").SetActive(false);
    }
    public void ChangeSceneToMap()
    {
        SceneManager.LoadScene(sceneName: "Map");
    }
}
