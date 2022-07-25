using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private string clueUnlocked;
    [SerializeField] private string popUpText;
    private GameObject popup;

    private void Awake()
    {
        popup = GameObject.FindGameObjectWithTag("Popup");
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    public void Win()
    {
        popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = popUpText;
        popup.SetActive(true);

        PlayerPrefs.SetInt("Number of clues unlocked", PlayerPrefs.GetInt("Number of clues unlocked") + 1);
        PlayerPrefs.SetInt(clueUnlocked, PlayerPrefs.GetInt("Number of clues unlocked"));
    }
}
