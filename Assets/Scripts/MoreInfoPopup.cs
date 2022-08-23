using UnityEngine;

public class MoreInfoPopup : MonoBehaviour
{
    [SerializeField] private string textToBeAdded;
    private GameObject plusButton;
    private GameObject closeButton;

    private void Awake()
    {
        plusButton  = transform.GetChild(0).Find("MoreInfo").gameObject;
        closeButton = transform.GetChild(0).Find("HidePopUp").gameObject;
    }

    private void Start()
    {
        VerifyButtons();
    }

    // Update is called once per frame
    void Update()
    {
        VerifyButtons();
    }
    
    public string TextToBeAdded
    {
        get
        {
            string temp = textToBeAdded;
            textToBeAdded = "";
            return temp; 
        }
        set { textToBeAdded = value; }
    }

    private void VerifyButtons()
    {
        if (textToBeAdded != "")
        {
            plusButton.SetActive(true);
            closeButton.SetActive(false);
        }
        else
        {
            plusButton.SetActive(false);
            closeButton.SetActive(true);
        }
    }
}
