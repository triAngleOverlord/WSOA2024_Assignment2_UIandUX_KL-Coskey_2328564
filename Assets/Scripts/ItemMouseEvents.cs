using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMouseEvents : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler ,IEndDragHandler, IDropHandler
{
    public Canvas canvas;

    public GameObject originalSlot;
    public GameObject newSlot;

    public RectTransform itemRect;
    public CanvasGroup itemCanvasGp;

    public ItemDetails itemDetails;
    public float amountStack;
    public void Awake()
    {
        itemRect = GetComponent<RectTransform>();
        itemCanvasGp = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(transform.name + " has been left-clicked");
        }*/

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(transform.name + " has been right-clicked");

            if (amountStack > 1)
            {
                GameObject[] slots = GameObject.FindGameObjectsWithTag("Avaliable");
                    if (slots != null)
                    {
                        GameObject splitItem = Instantiate(itemDetails.itemObject, slots[0].transform);
                        splitItem.transform.localPosition = Vector3.zero;
                        slots[0].tag = splitItem.tag;

                        amountStack--;
                        transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(amountStack.ToString());
                        splitItem.GetComponent<ItemMouseEvents>().amountStack = 1;
                        splitItem.gameObject.transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(splitItem.GetComponent<ItemMouseEvents>().amountStack.ToString());


            }

                    else
                    {
                        Debug.Log("There is no more space in your backpack");
                    }

            }

            else
            {
                Debug.Log("You cannot split stack anymore");
            }
            
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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(transform.name + " detected an OnDrop");

        if (eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.transform.tag == transform.tag)
            {
                Debug.Log(amountStack.ToString()+ " + "+ eventData.pointerDrag.GetComponent<ItemMouseEvents>().amountStack);
                amountStack += eventData.pointerDrag.GetComponent<ItemMouseEvents>().amountStack;
                Destroy(eventData.pointerDrag);
                
                transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(amountStack.ToString());

            }

            else
            {
                Debug.Log("Items do not match");
            }
            
        }
    }
}
