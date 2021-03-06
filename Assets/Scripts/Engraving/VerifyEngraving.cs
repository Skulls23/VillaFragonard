using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyEngraving : MonoBehaviour
{
    [SerializeField] private int numberToWin = 3;
    private int numCorrect;
    private Color baseColor;

    private void Awake()
    {
        baseColor = GetComponent<Image>().color;
    }

    public void VerifySprites()
    {

        GameObject[] go = GameObject.FindGameObjectsWithTag("Piece");


        if (go[0].GetComponent<Image>().sprite.name == go[1].GetComponent<Image>().sprite.name)// + "Print")
        {
            numCorrect++;
            go[0].GetComponent<Swap>().DeleteActualSprite();
            go[1].GetComponent<Swap>().DeleteActualSprite();
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
