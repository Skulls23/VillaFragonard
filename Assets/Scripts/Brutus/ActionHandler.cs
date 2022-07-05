using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    private bool isCorrectAnswer = false;

    public void Clicked()
    {
        transform.parent.gameObject.GetComponent<ChangingChoices>().ImageSelected(isCorrectAnswer);
    }

    public bool GetIsCorrectAnswer()
    {
        return isCorrectAnswer;
    }

    public void SetIsCorrectAnswer(bool state)
    {
        isCorrectAnswer = state;
    }
}
