using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if (aDirection[numText].Equals("END"))
            GameObject.Find("Gameplay").GetComponent<End>().Win();
        else if (numText < aText.Length)
            GetComponent<Text>().text = aText[numText];
    }

    public string GetActualDirection()
    {
        return aDirection[numText];
    }
}
