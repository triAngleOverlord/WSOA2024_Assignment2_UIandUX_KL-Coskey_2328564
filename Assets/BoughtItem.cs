using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class BoughtItem : MonoBehaviour
{
    public GameObject _item;
    public GameObject item;

    public ItemDetails itemDetails;

    public void Awake()
    {
        //_item = gameObject.transform.GetComponent<Purchase>().itemDetails.itemObject;
        //itemIntoBag();
    }
    public void itemIntoBag()
    {
        //GameObject bag = GameObject.Find("BackPack");
        GameObject existingItemSlot = GameObject.FindGameObjectWithTag(_item.tag);
       // Debug.Log(_item.tag);
        //Debug.Log(parentItem.tag);

        if (existingItemSlot == null)
        {
            GameObject[] slots = GameObject.FindGameObjectsWithTag("Avaliable");
            if (slots != null)
            {
                GameObject item = Instantiate(_item, slots[0].transform);
                slots[0].tag = item.tag;
                item.tag = "Untagged";

                itemDetails.amountInStack++;
                item.gameObject.transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(itemDetails.amountInStack.ToString());
            

            }

            else
            {
                Debug.Log("There is no more space in your backpack");
            }
            
            //item.gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(itemDetails.amountInStack.ToString());
        }

        else
        {
            item = existingItemSlot.gameObject.transform.GetChild(0).gameObject;
            itemDetails.amountInStack++;
            item.gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(itemDetails.amountInStack.ToString());
            //GameObject item = Instantiate(_item, parentItem.transform);

            //parentItem.tag = item.tag;
            //item.tag = "Untagged";
        }
            
        
    }
    /*
    public void chestUpgrade()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject extraChest = Instantiate(GameManager.Instance.slotUpgrade);
            extraChest.transform.SetParent(GameObject.Find("Slots_Chest").transform);
            extraChest.transform.localScale = Vector3.one;
            GameManager.Instance.chestSpaces.Add(extraChest.GetComponent<Transform>());

        }
            

       
        
    }*/
}
