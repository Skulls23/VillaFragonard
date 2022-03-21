using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private void Update()
    {
        MouseListener();
    }

    private void MouseListener()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetType() == typeof(BoxCollider2D))
                {
                    Debug.Log("yes");
                }
            }
        }
    }
}
