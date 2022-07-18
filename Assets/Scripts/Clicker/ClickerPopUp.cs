using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerPopUp : MonoBehaviour
{
    private int clickerNumber = -1;
    private int changeSceneNumber;

    private void Start()
    {
        changeSceneNumber = GameObject.Find("Gameplay").GetComponent<Clicker>().GetNumberOfElementToClick()-1;
    }

    public void EffectDependsOnNumber()
    {
        if (clickerNumber == changeSceneNumber)
            SceneManager.LoadScene(sceneName: "Map");
        else
            GameObject.FindGameObjectsWithTag("Popup")[0].SetActive(false);
    }

    public void SetClickerNumber(int number)
    {
        clickerNumber = number;
    }
}