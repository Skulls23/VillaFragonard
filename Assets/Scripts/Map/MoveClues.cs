using UnityEngine;
using UnityEngine.UI;

public class MoveClues : MonoBehaviour
{
    [SerializeField] private float distanceMaxXToBeFinished = 50f;
    [SerializeField] private float distanceMaxYToBeFinished = 120f;

    private GameObject[] aDestinations;
    private float startPosX;
    private float startPosY;

    private void Start()
    {
        if (! (PlayerPrefs.HasKey("Unlock secret") && PlayerPrefs.GetInt("Unlock secret") == 1))
        {
            aDestinations = GameObject.FindGameObjectsWithTag("ChoicePiece");
            startPosX = transform.position.x;
            startPosY = transform.position.y;
        }
        else
            Destroy(gameObject);
    }

    public void Move()
    {
        if (PlayerPrefs.GetInt("Number of clues unlocked") >= PlayerPrefs.GetInt("Number of clues to be unlocked"))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
        }
    }

    public void StopMove()
    {
        if (PlayerPrefs.GetInt("Number of clues unlocked") >= PlayerPrefs.GetInt("Number of clues to be unlocked"))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            for (int i = 0; i < aDestinations.Length; i++)
                if (aDestinations[i].transform.name != "-") //can't change the -
                    if (Mathf.Abs(transform.position.x - aDestinations[i].transform.position.x) <= distanceMaxXToBeFinished &&
                        Mathf.Abs(transform.position.y - aDestinations[i].transform.position.y) <= distanceMaxYToBeFinished)
                    {
                        ChangeImage(aDestinations[i]);
                        GameObject.Find("Gameplay").GetComponent<VerifyResultMap>().ChangeMade();
                    }
                        
        }
        ResetPosition();
    }

    private void ChangeImage(GameObject destination)
    {
        destination.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
    }

    private void ResetPosition()
    {
        gameObject.transform.position = new Vector3(startPosX, startPosY, gameObject.transform.position.z);
    }
}
