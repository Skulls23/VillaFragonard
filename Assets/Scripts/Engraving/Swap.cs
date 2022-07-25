using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap : MonoBehaviour
{
    [SerializeField] private Sprite[] aSprite;
    private int   spriteNumber;
    private float startPosY;

    private void Start()
    {
        GetComponent<Image>().sprite = aSprite[spriteNumber];
    }

    public void InitMove()
    {
        startPosY = Input.mousePosition.y;
    }

    public void EndMove()
    {
        float newPosY = Input.mousePosition.y;
        
        if (newPosY >= startPosY)
            SwapSprite("up");
        else if (newPosY <= startPosY)
            SwapSprite("down");
        else
            print("static");
    }
    
    private void SwapSprite(string str)
    {
        if (str == "up")
        {
            spriteNumber++;
            if (spriteNumber >= aSprite.Length)
                spriteNumber = 0;
        }
        else if (str == "down")
        {
            spriteNumber--;
            if (spriteNumber < 0)
                spriteNumber = aSprite.Length-1;
        }

        GetComponent<Image>().sprite = aSprite[spriteNumber];
    }
}
