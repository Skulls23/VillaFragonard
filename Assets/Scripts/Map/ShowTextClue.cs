using UnityEngine;
using UnityEngine.UI;

public class ShowTextClue : MonoBehaviour
{
    [SerializeField] string[] clues;

    private GameObject popup;

    // Awake is called before all the Start
    void Awake()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
        popup.SetActive(false);
    }

    public void ShowClue(int clueNumber)
    {
        print("here");
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = clues[clueNumber];
        popup.SetActive(true);
    }
}
