using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapClicker : MonoBehaviour
{
    [SerializeField] private List<GameObject> lOrdersCollider;
    [SerializeField] private List<string>     lOrdersNameScene;

    private void Update()
    {
        MouseListener();
    }

    private void MouseListener()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.GetType() == typeof(BoxCollider2D))
                    for (int i = 0; i < lOrdersNameScene.Count; i++)
                        if (hit.collider == lOrdersCollider[i].GetComponent<Collider2D>())
                            SceneManager.LoadScene(sceneName: lOrdersNameScene[i]);
        }
    }
}
