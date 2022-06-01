using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a better GridLayout system.
/// It allows everything inside to scale perfectly
/// </summary>
public class BetterGridLayout : MonoBehaviour
{
    public int rows;
    public int cols;
    private GameObject[] lPieces;
    void Start()
    {
        lPieces = GameObject.FindGameObjectsWithTag("Piece");

        RectTransform parentRect = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        gridLayout.cellSize = new Vector2(parentRect.rect.width / cols, parentRect.rect.height / rows);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                lPieces[i+j].transform.SetParent(gameObject.transform, false);
            }
        }
    }
}
