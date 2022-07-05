using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingChoices : MonoBehaviour
{
    private GameObject[] aChoicePieces;
    private GameObject[] aPieces;
    private Sprite[]     aSprites;
    private int pieceActuallyresearched = 0;
    private int[] aNumberAlreadyPlaced;

    private void Start()
    {
        aChoicePieces = GameObject.FindGameObjectsWithTag("ChoicePiece");
        aPieces       = GameObject.FindGameObjectsWithTag("Piece");
        aSprites      = Resources.LoadAll<Sprite>("Brutus/AEvariste-juniusbrutus");

        aPieces[pieceActuallyresearched].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, .35f);
        Scramble();
    }

    /// <summary>
    /// This method is called by <c>ActionHandler</c> when the player clicked on a <c>ChoicePiece</c> <br/>
    /// If the answer is correct then the <c>Piece</c> bound to the number of the picture is revealed on screen and the player must find the next.
    /// </summary>
    /// <param name="answer">Does the player clicked on the good picture ?</param>
    public void ImageSelected(bool answer)
    {
        if(answer == true)
        {
            aPieces[pieceActuallyresearched].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            aPieces[pieceActuallyresearched++].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0f);
        }

        if (pieceActuallyresearched >= aPieces.Length)
            GameObject.Find("Gameplay").GetComponent<End>().Win();
        else
        {
            aPieces[pieceActuallyresearched].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, .35f);
            Scramble();
        }
            
    }

    /// <summary>
    /// Change the image of All <c>ChoicePiece</c> <br/>
    /// </summary>
    private void Scramble()
    {
        string fileName;
        aNumberAlreadyPlaced    = new int[aChoicePieces.Length];
        aNumberAlreadyPlaced[0] = pieceActuallyresearched;

        int positionInArray = 1;
        int placeOfCorrectAnswer = Random.Range(0, aChoicePieces.Length);
        for(int i = 0; i < aChoicePieces.Length; i++)
        {
            if(placeOfCorrectAnswer == i)
            {
                fileName = "AEvariste-juniusbrutus_" + pieceActuallyresearched;
                aChoicePieces[i].GetComponent<ActionHandler>().SetIsCorrectAnswer(true);
                
            }
            else
            {
                int number = GetUniqueRandomNumber(positionInArray++);
                fileName = "AEvariste-juniusbrutus_" + number;
                aChoicePieces[i].GetComponent<ActionHandler>().SetIsCorrectAnswer(false);
            }

            for(int j = 0; j < aSprites.Length; j++)
            {
                if (aSprites[j].name.Equals(fileName))
                    aChoicePieces[i].GetComponent<Image>().sprite = aSprites[j];
            }
        }
    }

    /// <summary>
    /// This script returns a unique integer (to avoid to get multiple time the same image in choices list)
    /// </summary>
    /// <returns>The unique integer</returns>
    private int GetUniqueRandomNumber(int positionInArray)
    {
        int number = Random.Range(0, 30);

        bool isAlreadyPlaced = true;
        while (isAlreadyPlaced)
        {
            isAlreadyPlaced = false;
                for (int j = 0; j < aNumberAlreadyPlaced.Length && !isAlreadyPlaced; j++)
                    if (number == aNumberAlreadyPlaced[j])
                    {
                        isAlreadyPlaced = true;
                        number = Random.Range(0, 30);
                    }
        }

        aNumberAlreadyPlaced[positionInArray] = number;
        return number;
    }
}
