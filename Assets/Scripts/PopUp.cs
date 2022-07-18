using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script handles all button actions
/// </summary>
public class PopUp : MonoBehaviour
{
    public void ClosePopUp()
    {
        GameObject.FindGameObjectsWithTag("Popup")[0].SetActive(false);
    }
    public void ChangeSceneToMap()
    {
        SceneManager.LoadScene(sceneName: "Map");
    }
    
    public void PrintMoreText()
    {
        GameObject.FindGameObjectsWithTag("Popup")[0].transform.GetChild(0).Find("Text").GetComponent<Text>().text = GameObject.FindGameObjectsWithTag("Popup")[0].GetComponent<MoreInfoPopup>().TextToBeAdded;
        GameObject.FindGameObjectsWithTag("Popup")[0].GetComponent<MoreInfoPopup>().TextToBeAdded = "";
    }

    public void DestroyPopup()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
