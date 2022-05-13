using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DoubleTapZoom : MonoBehaviour
{
    int tap;
    float interval = 0.5f;
    bool readyForDoubleTap;
    bool doubleDone = false;
    public void Clicked()
    {
        Debug.Log("0");
        tap++;

        if (tap == 1)
        {
            Debug.Log("1");
            //do stuff
            readyForDoubleTap = true;
            StartCoroutine(DoubleTapInterval());
        }
        else if (tap > 1 && readyForDoubleTap)
        {
            //do stuff
            Debug.Log("4");

            tap = 0;
            doubleDone = true;
        }
    }

    IEnumerator DoubleTapInterval()
    {
        Debug.Log("2");
        yield return new WaitForSeconds(interval);
        Debug.Log("3");

        //if the user didn't clicked a second time in time, we reset the tap number
        if (!doubleDone)
        {
            readyForDoubleTap = false;
            tap = 0;
        }
        doubleDone = false;
    }
}
