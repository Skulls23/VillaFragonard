using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToScene : MonoBehaviour
{
    [SerializeField] private string redirection;

    public void Redirect()
    {
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
