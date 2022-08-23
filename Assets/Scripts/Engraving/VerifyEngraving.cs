using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyEngraving : MonoBehaviour
{
    [SerializeField] private int numberToWin = 3;
    private int numCorrect;
    private Color baseColor;
    private GameObject tirage;
    private GameObject plaque;

    private void Awake()
    {
        baseColor = GetComponent<Image>().color;
        tirage = GameObject.Find("Tirage");
        plaque = GameObject.Find("Plaque");
    }

    public void VerifySprites()
    {
        if (tirage.GetComponent<Image>().sprite.name == "TIRAGE-"+ plaque.GetComponent<Image>().sprite.name)
        {
            numCorrect++;
            tirage.GetComponent<Swap>().DeleteActualSprite();
            plaque.GetComponent<Swap>().DeleteActualSprite();
            transform.GetComponent<Image>().color = Color.green;
            StartCoroutine(ReturnColorToNormal(0.6f));
        }
        else
        {
            transform.GetComponent<Image>().color = Color.red;
            StartCoroutine(ReturnColorToNormal(0.6f));
        }
        
        if (numCorrect == numberToWin)
        {
            GameObject.Find("Gameplay").GetComponent<End>().Win();
        }
    }

    IEnumerator ReturnColorToNormal(float f)
    {
        yield return new WaitForSeconds(f);
        transform.GetComponent<Image>().color = baseColor;
    }

}
