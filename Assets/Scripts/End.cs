using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private string clueUnlocked;
    [SerializeField] private string popUpText;
    [Header("For the visit end game (leave empty otherwise)")]
    [SerializeField] private string title;
    [SerializeField] private Sprite sprite;
    private GameObject popup;

    private void Awake()
    {
        popup = GameObject.Find("PopUpInfo");
        if(popup == null)
            popup = GameObject.Find("PopUp");
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    public void Win()
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
        
        if(title != "" && sprite != null)
        {
            popup.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = sprite;
            popup.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = title;
        }
        
        popup.SetActive(true);

        PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
        PlayerPrefs.SetInt(clueUnlocked, PlayerPrefs.GetInt("Number of clues unlocked"));
    }
}
