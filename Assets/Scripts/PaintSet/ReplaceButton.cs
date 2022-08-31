using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplaceButton : MonoBehaviour
{
    private GameObject button;

    private void Awake()
    {
        button = GameObject.Find("ReturnMap");
    }

    public void ChangePlace()
    {
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0.475f, 0.05f);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0.525f, 0.15f);
        button.GetComponent<RectTransform>().pivot     = new Vector2(0.5f, 0.5f);
        button.GetComponent<RectTransform>().rotation  = new Quaternion(180f, 0f, 0f, 0f);
        button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/SkipArrow");
    }
}
