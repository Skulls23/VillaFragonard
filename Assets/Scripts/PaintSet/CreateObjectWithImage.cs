using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObjectWithImage : MonoBehaviour
{
    private int          spriteSelector = 0;
    private int          numberPlaced   = 0;
    private Sprite[]     aSprites;
    private GameObject[] aObjectsInHierarchy;

    // Start is called before the first frame update
    void Start()
    {
        aSprites = Resources.LoadAll<Sprite>("PaintSet/Objects");
        
        System.Array.Sort(lf);//Avoid duplicates from the LoadAll

        Shambles(500);
        
        aObjectsInHierarchy = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            aObjectsInHierarchy[i] = transform.GetChild(i).gameObject;

        PlaceImages();
    }

    public void ObjectPlaced()
    {
        if(++numberPlaced % 8 == 0)
            PlaceImages();
    }

    private void Shambles(int scrambleNumber)
    {
        
        int    randomNumber;
        int    previousNumber = 0;
        int    objectNumber = aSprites.Length;
        Sprite tempSpriteA  = null;
        Sprite tempSpriteB  = null;

        for (int i = 0; i<scrambleNumber; i++)
        {
            randomNumber = Random.Range(0, objectNumber);
            if(tempSpriteA != null)
            {
                tempSpriteB = aSprites[randomNumber];
                aSprites[randomNumber] = tempSpriteA;
                aSprites[previousNumber] = tempSpriteB;

                tempSpriteA = tempSpriteB = null;
            }
            else
            {
                tempSpriteA = aSprites[randomNumber];
                previousNumber = randomNumber;
            }
        }
    }

    private void PlaceImages()
    {
        for (int i = 0; i < aObjectsInHierarchy.Length; i++)
        {
            if (spriteSelector < aSprites.Length)
            {
                aObjectsInHierarchy[i].GetComponent<Image>().sprite = aSprites[spriteSelector++];
                aObjectsInHierarchy[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
            else
                Disappear(aObjectsInHierarchy[i]);
        }
    }

    private void Disappear(GameObject o)
    {
        o.GetComponent<Image>().sprite = null;
        o.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
