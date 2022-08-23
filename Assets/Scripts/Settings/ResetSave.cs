using UnityEngine;

public class ResetSave : MonoBehaviour
{
    private GameObject stairsButton;
    private GameObject reserveButton;
    private GameObject copiesButton;

    private void Awake()
    {
        stairsButton  = GameObject.Find("Stairs");
        reserveButton = GameObject.Find("Reserve");
        copiesButton  = GameObject.Find("Copies");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
