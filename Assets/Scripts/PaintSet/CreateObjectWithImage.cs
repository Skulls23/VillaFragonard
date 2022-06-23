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
        Shambles(500);
        
        aObjectsInHierarchy = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            aObjectsInHierarchy[i] = transform.GetChild(i).gameObject;

        for(int i = 0;i < aSprites.Length;i++)
            print(aSprites[i].name);
        PlaceImages();
    }

    public void ObjectPlaced()
    {
        if(++numberPlaced % 8 == 0) //TODO numero maximum d'objet, comme ca on refresh et on lock le jeu
        {
            PlaceImages();
        }
    }

    private void Shambles(int scrambleNumber)
    {
        int    objectNumber = aSprites.Length;
        int    randomNumber;
        Sprite tempSpriteA = null;
        Sprite tempSpriteB = null;

        for (int i = 0; i<scrambleNumber; i++)
        {
            randomNumber = Random.Range(0, objectNumber);
            if(tempSpriteA != null)
            {
                tempSpriteB = aSprites[randomNumber];
                aSprites[randomNumber] = tempSpriteA;
                tempSpriteA = tempSpriteB;
            }
            else
                tempSpriteA = aSprites[randomNumber];
        }
    }

    private void PlaceImages()
    {
        for (int i = 0; i < aObjectsInHierarchy.Length; i++)
        {
            if (spriteSelector < aSprites.Length)
            {
                print(aSprites[spriteSelector] + " " +spriteSelector);
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
