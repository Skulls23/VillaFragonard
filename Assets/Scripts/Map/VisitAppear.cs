using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitAppear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Number of clues unlocked") >= 6)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
