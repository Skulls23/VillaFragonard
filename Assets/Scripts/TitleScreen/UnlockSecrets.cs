using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecrets : MonoBehaviour
{
    private GameObject secretButton;
    // Start is called before the first frame update
    void Start()
    {
        secretButton = GameObject.Find("Secret");
        if (PlayerPrefs.HasKey("Unlock secret") && PlayerPrefs.GetInt("Unlock secret") == 1)
            secretButton.SetActive(true);
        else
            secretButton.SetActive(false);
    }
}
