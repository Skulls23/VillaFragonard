using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool isTrue;
    private Color baseColor;

    private void Start()
    {
        baseColor = transform.GetComponent<Image>().color;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
       
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void Answer()
    {
        if(isTrue)
        {
            transform.GetComponent<Image>().color = Color.green;
            StartCoroutine(ReturnColorToNormal(0.5f));
        }
        else
        {
            transform.GetComponent<Image>().color = Color.red;
            StartCoroutine(ReturnColorToNormal(0.5f));
        }
    }

    IEnumerator ReturnColorToNormal(float f)
    {
        yield return new WaitForSeconds(f);
        transform.GetComponent<Image>().color = baseColor;
    }
}
