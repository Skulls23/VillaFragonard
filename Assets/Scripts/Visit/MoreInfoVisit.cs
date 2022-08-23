using UnityEngine;

public class MoreInfoVisit : MonoBehaviour
{
    [Header("Marguerite")]
    [SerializeField] private string textToBeAdded;
    [SerializeField] private string titleToBeAdded;
    [SerializeField] private Sprite spriteToBeAdded;
    
    [Header("Alexandre")]
    [SerializeField] private string textToBeAdded2;
    [SerializeField] private string titleToBeAdded2;
    [SerializeField] private Sprite spriteToBeAdded2;
    
    private GameObject plusButton;
    private GameObject closeButton;

    private void Awake()
    {
        plusButton = transform.GetChild(0).Find("MoreInfo").gameObject;
        closeButton = transform.GetChild(0).Find("HidePopUp").gameObject;
    }

    private void Start()
    {
        VerifyButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (textToBeAdded2 != "" && textToBeAdded == "")
        {
            textToBeAdded = textToBeAdded2;
            textToBeAdded2 = "";
            titleToBeAdded = titleToBeAdded2;
            titleToBeAdded2 = "";
            spriteToBeAdded = spriteToBeAdded2;
            spriteToBeAdded2 = null;
        }


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

    public string TitleToBeAdded
    {
        get
        {
            string temp = titleToBeAdded;
            titleToBeAdded = "";
            return temp;
        }
        set { titleToBeAdded = value; }
    }

    public Sprite SpriteToBeAdded
    {
        get
        {
            Sprite temp = spriteToBeAdded;
            spriteToBeAdded = null;
            return temp;
        }
        set { spriteToBeAdded = value; }
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
