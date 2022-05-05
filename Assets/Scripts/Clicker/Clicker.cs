using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private List<string> lOrderStrings;
    [SerializeField] private List<string> lTextPopUp;
    //[SerializeField] private List<GameObject> lOrderButtons;

    [SerializeField] private float timeToWaitBeforeSceneSwitch = 2f;
    [SerializeField] private string clueName;

    private GameObject popUp;
    private int missionNumber = 0;

    private void Start()
    {
        popUp = GameObject.Find("PopUp");
        popUp.SetActive(false);
        text.text = lOrderStrings[missionNumber];
    }

    private void Update()
    {
        //MouseListener();
    }

    /*private void MouseListener()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.GetType() == typeof(BoxCollider2D) && hit.collider.transform.gameObject.name == lOrderButtons[missionNumber].name)
                    MissionStepComplete();
        }
    }*/

    public void ButtonClicked(int numButton)
    {
        if (numButton == missionNumber)
            MissionStepComplete();
    }

    private void MissionStepComplete()
    {
        PopUp();
        missionNumber++;
        if (lOrderStrings.Count > missionNumber)
            text.text = lOrderStrings[missionNumber];
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

    private void PopUp()
    {
        if(string.Compare(lTextPopUp[missionNumber], "") != 0)
        {
            popUp.SetActive(true);
            popUp.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = lTextPopUp[missionNumber];
        }
    }
}
