using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesRevealer : MonoBehaviour
{
    [SerializeField] private List<GameObject> lClues = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lClues.Count; i++)
            if(PlayerPrefs.HasKey(lClues[i].name) && PlayerPrefs.GetInt(lClues[i].name) == 1)
                lClues[i].SetActive(true);
            else
                lClues[i].SetActive(false);
    }
}
