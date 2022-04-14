using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferencesVerifier : MonoBehaviour
{
    [SerializeField] private List<GameObject> lColliders = new List<GameObject>();
    private int differencesToFind;

    private void Start()
    {
        differencesToFind = lColliders.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.GetType() == typeof(BoxCollider2D))
            {
                hit.transform.parent.gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}
