using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMouseEvents : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    public GameObject originalSlot;
    public GameObject newSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(transform.name + " has been left-clicked");
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(transform.name + " has been right-clicked");
        }

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalSlot = transform.parent.gameObject;
        transform.parent = GameObject.Find("Canvas").transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    

}
