using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public void ClosePopUp()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
    }
}
