using UnityEngine;
using UnityEngine.UI;

public class ClueLogoClicked : MonoBehaviour
{
    public void ShowClue()
    {
        if(gameObject.GetComponent<Image>().color.a == 1f)
            GameObject.Find("Gameplay").GetComponent<ShowTextClue>().ShowClue(transform.GetSiblingIndex());
    }
}
