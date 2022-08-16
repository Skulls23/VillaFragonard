using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script handles all button actions
/// </summary>
public class PopUp : MonoBehaviour
{
    public GameObject popUp;

    private void Awake()
    {
        popUp = this.transform.parent.parent.gameObject;
    }
    
    public void ClosePopUp()
    {
        popUp.SetActive(false);
    }
    public void ChangeSceneToMap()
    {
        SceneManager.LoadScene(sceneName: "Map");
    }
    
    public void PrintMoreText()
    {
        popUp.transform.GetChild(0).Find("Text").GetComponent<Text>().text = popUp.GetComponent<MoreInfoPopup>().TextToBeAdded;
    }

    public void PrintMoreVisit()
    {
        popUp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text    = popUp.GetComponent<MoreInfoVisit>().TextToBeAdded;
        popUp.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = popUp.GetComponent<MoreInfoVisit>().SpriteToBeAdded;
        popUp.transform.GetChild(0).GetChild(2).GetComponent<Text>().text    = popUp.GetComponent<MoreInfoVisit>().TitleToBeAdded;
    }

    public void DestroyPopup()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
