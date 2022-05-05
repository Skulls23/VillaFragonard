using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public void ClosePopUp()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
    }
    public void ChangeSceneToMap()
    {
        SceneManager.LoadScene(sceneName: "Map");
    }
}
