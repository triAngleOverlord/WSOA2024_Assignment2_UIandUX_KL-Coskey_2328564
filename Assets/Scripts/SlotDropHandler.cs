using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(transform.name+" detected an OnDrop");

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            transform.tag = eventData.pointerDrag.transform.tag;
        }
    }
}
