using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjects : MonoBehaviour
{
    private GameObject objectsPopUp;

    // Start is called before the first frame update
    void Start()
    {
        objectsPopUp = GameObject.Find("ObjectsPopUp");
        objectsPopUp.SetActive(false);
    }

    public void Show()
    {
        objectsPopUp.SetActive(true);
    }
}
