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
        {
            spriteNumber++;
            if (spriteNumber >= aSprite.Length)
                spriteNumber = 0;
            SwapSprite();
        }
        else if (newPosY <= startPosY)
        {
            spriteNumber--;
            
            SwapSprite();
        }
            
        else
            print("static");
    }
    
    private void SwapSprite()
    {
        if (aSprite.Length != 0)
        {
            if (spriteNumber < 0)
                spriteNumber = aSprite.Length - 1;
            else if (spriteNumber >= aSprite.Length)
                spriteNumber = 0;

            GetComponent<Image>().sprite = aSprite[spriteNumber];
        }
    }
    
    

    public void DeleteActualSprite()
    {
        if (aSprite.Length != 0)
        {
            Sprite[] aSpriteReplacer = new Sprite[aSprite.Length - 1];
            int placement = 0;
            for (int i = 0; i < aSprite.Length; i++)
            {
                if (i != spriteNumber)
                    aSpriteReplacer[placement++] = aSprite[i];
            }
            aSprite = aSpriteReplacer;
            SwapSprite();
        }
    }
}
