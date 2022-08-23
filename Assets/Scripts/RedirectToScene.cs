using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToScene : MonoBehaviour
{
    [SerializeField] private string redirection;

    public void Redirect()
    {
        SceneManager.LoadScene(sceneName: redirection);
    }
    
    public void RedirectAndErasePersistent()
    {
        DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
        if (! string.IsNullOrEmpty(dataDir.Name))
        {
            dataDir.Delete(true);
        }
        SceneManager.LoadScene(sceneName: redirection);
    }

    public void RedirectUrl()
    {
        Application.OpenURL(redirection);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
