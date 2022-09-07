using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObjectWithImage : MonoBehaviour
{
    [SerializeField] private int placedAtStart = 8;
    private int                  spriteSelector = 0;
    private int                  numberPlaced   = 0;
    private List<Sprite>         lSprites;
    private GameObject[]         aObjectsInHierarchy;

    // Start is called before the first frame update
    void Start()
    {
        lSprites = new List<Sprite>(Resources.LoadAll<Sprite>("PaintSet/Objects"));

        PlaceRandomOnSet();
        //RemoveAlreadyPlaceImage();
        Shambles(500);
        
        aObjectsInHierarchy = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            aObjectsInHierarchy[i] = transform.GetChild(i).gameObject;

        PlaceImages();
    }

    public void ObjectPlaced()
    {
        if (++numberPlaced % 8 == 0)
            PlaceImages();
    }
    
    private void PlaceRandomOnSet()
    {
        int randomNumber;
        for (int i = 0; i < placedAtStart; i++)
        {
            randomNumber = Random.Range(0, lSprites.Count);
            if(GameObject.Find(lSprites[i].name) != null && GameObject.Find(lSprites[i].name).GetComponent<Image>().color.a == 0)
            {
                GameObject.Find(lSprites[i].name).GetComponent<Image>().color = new Color(255, 255, 255, 1f); //set albedo to 1
                lSprites.RemoveAt(i);
            }
            else
            {
                i--;
            }
        }
    }

    private void RemoveAlreadyPlaceImage()
    {
        for(int i = 0; i < lSprites.Count; i++)
            if (GameObject.Find(lSprites[i].name).GetComponent<Image>().color.a != 0)
            {
                
                i--;
            }
    }

    private void Shambles(int scrambleNumber)
    {
        int    randomNumber;
        int    previousNumber = 0;
        Sprite tempSpriteA  = null;
        Sprite tempSpriteB  = null;

        for (int i = 0; i<scrambleNumber; i++)
        {
            randomNumber = Random.Range(0, lSprites.Count);
            if (tempSpriteA != null)
            {
                tempSpriteB = lSprites[randomNumber];
                lSprites[randomNumber] = tempSpriteA;
                lSprites[previousNumber] = tempSpriteB;

                tempSpriteA = tempSpriteB = null;
            }
            else
            {
                tempSpriteA = lSprites[randomNumber];
                previousNumber = randomNumber;
            }
        }
    }

    private void PlaceImages()
    {
        for (int i = 0; i < aObjectsInHierarchy.Length; i++)
            if (spriteSelector < lSprites.Count)
            {
                aObjectsInHierarchy[i].GetComponent<Image>().sprite = lSprites[spriteSelector++];
                aObjectsInHierarchy[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
            else
                Disappear(aObjectsInHierarchy[i]);
    }

    private void Disappear(GameObject o)
    {
        o.GetComponent<Image>().sprite = null;
        o.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
