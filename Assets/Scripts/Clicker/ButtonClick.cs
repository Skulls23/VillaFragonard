using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] int numButton;

    private Clicker      clicker;
    private void Start()
    {
        clicker      = GameObject.Find("Gameplay").GetComponent<Clicker>();
    }

    public void Clicked()
    {
        clicker.GetComponent<Clicker>().ButtonClicked(numButton);
    }
}
