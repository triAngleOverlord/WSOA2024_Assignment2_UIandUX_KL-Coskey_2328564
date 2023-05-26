using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.transform.tag != "Untagged")
            {
                if(transform.tag == "Avaliable")
            {
                eventData.pointerDrag.transform.SetParent(transform, true);
                eventData.pointerDrag.transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                transform.tag = eventData.pointerDrag.transform.tag;

                if (transform.parent.transform.name == "BackpackSlots")
                {
                    GameManager.backPackSpace--;
                    Debug.Log(GameManager.backPackSpace);
                }

            }

            }
            
            
        }
    }
}
