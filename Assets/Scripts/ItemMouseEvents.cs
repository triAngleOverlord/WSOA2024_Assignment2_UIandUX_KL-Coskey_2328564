using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMouseEvents : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    [SerializeField] Canvas canvas;

    public GameObject originalSlot;
    public GameObject newSlot;

    public RectTransform itemRect;
    public CanvasGroup itemCanvasGp;

    public void Awake()
    {
        itemRect = GetComponent<RectTransform>();
        itemCanvasGp = GetComponent<CanvasGroup>();
    }

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
        originalSlot.transform.tag = "Avaliable";
        Debug.Log(originalSlot.name);
        transform.SetParent(canvas.transform,true);
        Debug.Log(transform.name + " begun drag");
        itemCanvasGp.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        itemRect.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        //Debug.Log(transform.name + " is on drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent != canvas.transform)
        {
            Debug.Log(transform.parent.name + " is the new parent");
            itemCanvasGp.blocksRaycasts = true;

        }
        else
        {
            Debug.Log("Item cannot be placed into space");
            originalSlot.transform.tag = transform.tag;
            transform.SetParent(originalSlot.transform,true);
            itemRect.anchoredPosition = Vector3.zero;
            itemCanvasGp.blocksRaycasts = true;
        }
        
    }

    

}
