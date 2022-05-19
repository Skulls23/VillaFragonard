using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;

public class DoubleTapZoom : MonoBehaviour
{
    [SerializeField] private float MaxDelayToDoubleTap = 0.5f;

    private string[] aTxt;

    private int tap;
    private bool readyForDoubleTap;
    private bool doubleDone = false;

    private Sprite sprite;

    private void Start()
    {
        string fullText;
        sprite = GetComponent<Image>().sprite;
        if(sprite.name != "3f051a")
        {
            StreamReader reader = new StreamReader("Assets/Resources/PaintSet/Texts/" + sprite.name + ".txt");
            aTxt = reader.ReadToEnd().Split('-');
            reader.Close();
        }
    }

    public void Clicked()
    {
        tap++;

        if (tap == 1)
        {
            //do stuff
            readyForDoubleTap = true;
            StartCoroutine(DoubleTapInterval());
        }
        else if (tap > 1 && readyForDoubleTap)
        {
            //do stuff
            RevealPopup();

            tap = 0;
            doubleDone = true;
        }
    }

    IEnumerator DoubleTapInterval()
    {
        yield return new WaitForSeconds(MaxDelayToDoubleTap);

        //if the user didn't clicked a second time in time, we reset the tap number
        if (!doubleDone)
        {
            readyForDoubleTap = false;
            tap = 0;
        }
        doubleDone = false;
    }

    private void RevealPopup()
    {
        GameObject.Find("Gameplay").GetComponent<PopupSetup>().RevealPopup(aTxt[0], aTxt[1], sprite);
    }
}
