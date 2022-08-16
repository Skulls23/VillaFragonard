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

    private void Awake()
    {
        plusButton = transform.GetChild(0).Find("MoreInfo").gameObject;
    }

    private void Start()
    {
        if (textToBeAdded != "")
        {
            plusButton.SetActive(true);
        }
        else
        {
            plusButton.SetActive(false);
        }
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
            

        if (textToBeAdded != "")
        {
            plusButton.SetActive(true);
        }
        else
        {
            plusButton.SetActive(false);
        }
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
}
