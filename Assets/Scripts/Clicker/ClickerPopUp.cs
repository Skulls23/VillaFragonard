using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerPopUp : MonoBehaviour
{
    private int number = -1;
    [SerializeField] private int changeSceneNumber;

    private void Start()
    {
        //TODO faire un lien et chercher directement via la taille de la liste Gameplay
    }

    public void EffectDependsOnNumber(int number, int changeSceneNumber)
    {
        if (number == changeSceneNumber)
            SceneManager.LoadScene(sceneName: "Map");
        else
            GameObject.FindGameObjectsWithTag("Popup")[0].SetActive(false);
    }
}