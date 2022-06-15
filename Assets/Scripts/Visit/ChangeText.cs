using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private string[] aDirection;
    [SerializeField] private string[] aText;
    private int numText = -1;

    private void Start()
    {
        CorrectAnswer();
    }

    public void CorrectAnswer()
    {
        numText++;
        NextText();
    }

    private void NextText()
    {
        if (numText < aText.Length)
        {
            GameObject.Find("Text").GetComponent<TMP_Text>().text = aText[numText];
        }
    }

    public string GetActualDirection()
    {
        return aDirection[numText];
    }
}
