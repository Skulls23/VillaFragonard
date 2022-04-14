using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesRevealer : MonoBehaviour
{
    [SerializeField] private List<GameObject> clues = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < clues.Count; i++)
            if(PlayerPrefs.HasKey(clues[i].name) && PlayerPrefs.GetInt(clues[i].name) == 1)
                clues[i].SetActive(true);
            else
                clues[i].SetActive(false);
    }
}
