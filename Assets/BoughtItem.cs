using TMPro;
using UnityEngine;

public class BoughtItem : MonoBehaviour
{
    public GameObject _item;
    public GameObject item;
    public float valueSelected;

    public ItemDetails itemDetails;

    
    public void itemIntoBag()
    {
        _item = itemDetails.itemObject;
        GameObject existingItemSlot = GameObject.FindGameObjectWithTag(_item.tag);
        

        if (existingItemSlot == null)
        {
            foreach (Transform slot in GameObject.Find("BackpackSlots").transform)
            {
                if (slot.transform.CompareTag("Avaliable"))
                {
                    GameObject item = Instantiate(_item, slot.transform);
                    item.transform.localPosition = Vector3.zero;
                    slot.tag = item.tag;
                    //Debug.Log(item.tag);
                    //item.tag = "Untagged";
                    item.GetComponent<ItemMouseEvents>().amountStack += valueSelected;
                    //itemDetails.amountInStack += valueSelected;
                    item.gameObject.transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(item.GetComponent<ItemMouseEvents>().amountStack.ToString());
                    GameObject pop = transform.GetComponent<POPUPDetails>().popUpThing;
                    item.GetComponent<ItemUse>().popUpThing = pop;
                    GameManager.backPackSpace--;
                    Debug.Log(GameManager.backPackSpace);
                    break;
                }
            }
        }

        else
        {
            item = existingItemSlot.gameObject;
            item.GetComponent<ItemMouseEvents>().amountStack += valueSelected;
            
            existingItemSlot.gameObject.transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(item.GetComponent<ItemMouseEvents>().amountStack.ToString());
            
        }
            
        
    }
}
