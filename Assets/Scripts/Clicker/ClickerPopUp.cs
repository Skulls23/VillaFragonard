using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerPopUp : MonoBehaviour
{
    private int number = -1;
    private int changeSceneNumber;

    private void Start()
    {
        changeSceneNumber = GameObject.Find("Gameplay").GetComponent<Clicker>().GetNumberOfElementToClick();
    }

    public void EffectDependsOnNumber()
    {
        if (number == changeSceneNumber)
            SceneManager.LoadScene(sceneName: "Map");
        else
            GameObject.FindGameObjectsWithTag("Popup")[0].SetActive(false);
    }
}