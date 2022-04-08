using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private bool isTrue;
    [SerializeField] private float timeToWaitBeforeSceneSwitch = 2f;

    private Color baseColor;


    private void Start()
    {
        baseColor = transform.GetComponent<Image>().color;
    }

    public void Answer()
    {
        if(isTrue)
        {
            transform.GetComponent<Image>().color = Color.green;
            StartCoroutine(WaitToChangeScene());
        }
        else
        {
            transform.GetComponent<Image>().color = Color.red;
            StartCoroutine(ReturnColorToNormal(0.8f));
        }
    }
    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(timeToWaitBeforeSceneSwitch);
        SceneManager.LoadScene(sceneName: "Map");
    }

    IEnumerator ReturnColorToNormal(float f)
    {
        yield return new WaitForSeconds(f);
        transform.GetComponent<Image>().color = baseColor;
    }
}
