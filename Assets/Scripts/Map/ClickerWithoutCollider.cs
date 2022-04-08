using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerWithoutCollider : MonoBehaviour
{
    [SerializeField] private string redirection;

    public void Redirect()
    {
        Debug.Log("here");
        SceneManager.LoadScene(sceneName: redirection);
    }
}
