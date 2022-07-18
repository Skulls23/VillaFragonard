using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void DestroyPopup()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
