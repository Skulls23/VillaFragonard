using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allow to activate the pop up to get info
/// </summary>
public class DoubleTapZoom : MonoBehaviour
{
    [SerializeField] private float MaxDelayToDoubleTap = 0.3f;

    private string[] aTxt;

    private int tap;
    private bool readyForDoubleTap;
    private bool doubleDone = false;

    public void Clicked()
    {
        if (GetComponent<Image>().color.a != 0)
        {
            tap++;

            if (tap == 1)
            {
                readyForDoubleTap = true;
                StartCoroutine(DoubleTapInterval());
            }
            else if (tap > 1 && readyForDoubleTap)
            {
                RevealPopup();

                tap = 0;
                doubleDone = true;
            }
        }
    }

    public void ClickedMap()
    {
        if (GetComponent<Image>().color.a != 0)
        {
            tap++;

            if (tap == 1)
            {
                readyForDoubleTap = true;
                StartCoroutine(DoubleTapInterval());
            }
            else if (tap > 1 && readyForDoubleTap)
            {
                GameObject.Find("Gameplay").GetComponent<ShowTextClue>().ShowClue(transform.GetSiblingIndex());

                tap = 0;
                doubleDone = true;
            }
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
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(Application.persistentDataPath + "/" + GetComponent<Image>().sprite.name + ".txt", Encoding.UTF8);
            if (reader.Peek() != -1)
            {
                print("not wrote");
                aTxt = reader.ReadToEnd().Split('\n');
                reader.Close();

                GameObject.Find("Gameplay").GetComponent<PopupSetup>().RevealPopupInfo(aTxt[0], aTxt[1], GetComponent<Image>().sprite);
            }
        }
        catch (FileNotFoundException)
        {
            print("wrote");
            TextAsset txtAsset = Resources.Load<TextAsset>("PaintSet/Texts/" + GetComponent<Image>().sprite.name);
            if (txtAsset != null && txtAsset.text.Length > 0) //TODO REMOVE LA DEUXIEME CONDITION
            {
                string txtContent = txtAsset.text;
                System.IO.File.WriteAllText(Application.persistentDataPath + "/" + GetComponent<Image>().sprite.name + ".txt", txtContent, Encoding.UTF8);
                reader = new StreamReader(Application.persistentDataPath + "/" + GetComponent<Image>().sprite.name + ".txt", Encoding.UTF8);

                aTxt = reader.ReadToEnd().Split('-'); //0 is title, 1 is the body
                reader.Close();

                GameObject.Find("Gameplay").GetComponent<PopupSetup>().RevealPopupInfo(aTxt[0], aTxt[1], GetComponent<Image>().sprite);
            }
        }
    }
}
