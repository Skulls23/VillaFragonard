using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redirection : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private List<string>     lOrdersString;
    [SerializeField] private List<GameObject> lOrdersCollider;

    [SerializeField] private float timeToWaitBeforeSceneSwitch = 2f;
    [SerializeField] private string clueName;

    private int missionNumber = 0;

    private void Start()
    {
        text.text = lOrdersString[missionNumber];
    }

    private void Update()
    {
        MouseListener();
    }

    private void MouseListener()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.GetType() == typeof(BoxCollider2D) && hit.collider.transform.gameObject.name == lOrdersCollider[missionNumber].name)
                    missionStepComplete();
        }
    }

    private void missionStepComplete()
    {
        missionNumber++;
        if (lOrdersCollider.Count > missionNumber)
            text.text = lOrdersString[missionNumber];
        else
        {
            text.text = "Niveau fini";
            PlayerPrefs.SetInt(clueName, 1);
            StartCoroutine(WaitToChangeScene());
        }
            
    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(timeToWaitBeforeSceneSwitch);
        SceneManager.LoadScene(sceneName: "Map");
    }
}
