using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public float amountStack;
    public float _sellPrice;

    public ItemDetails itemDetails;

    public Purchase buyStuff;
    public GameObject popUpThing;


    public void thisItemToSell()
    {
        if (popUpThing.activeSelf == false)
        {
            popUpThing.SetActive(true);
            setPopUp();

        }

        else
        {
            setPopUp();
        }


    }

    public void setPopUp()
    {
        itemDetails = transform.GetComponent<BoughtItem>().itemDetails;
        //popUpThing.transform.SetParent(transform);
        popUpThing.transform.localPosition = Vector3.right * 200;
        //GameObject.Find("Slider").GetComponent<Slider>().value = 1;

        //buyStuff = GameObject.Find("BuyButton").GetComponent<BuyingPopUp>();
        amountStack = itemDetails.amountInShop;
        _sellPrice = itemDetails.sellingPrice;

        //GameManager.c_itemName = transform.name;
        //GameManager.c_itemPrice = price;
        //GameManager.c_itemAmount = amountLeft;

        GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = new string(transform.name);
        GameObject.Find("Slider").GetComponent<Slider>().maxValue = amountStack;
        GameObject.Find("Slider").GetComponent<Purchase>().itemDetails = itemDetails;
        GameObject.Find("ConfirmPurchase").GetComponent<Purchase>().itemDetails = itemDetails;
        GameObject.Find("ConfirmPurchase").GetComponent<Purchase>().itemButton = this.gameObject;
        GameObject.Find("TotalPrice").GetComponent<TextMeshProUGUI>().text = new string("$" + _sellPrice.ToString());
        GameObject.Find("AvaliableStock").GetComponent<TextMeshProUGUI>().text = new string(amountStack.ToString());




    }

    public void chestUpgrade()
    {
        if (GameObject.Find("CHEST")==null)
        {
            UnityEngine.Debug.Log("You can't use the key here");
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject extraChest = Instantiate(GameManager.Instance.slotUpgrade);
                extraChest.transform.SetParent(GameObject.Find("Slots_Chest").transform);
                extraChest.transform.localScale = Vector3.one;
                GameManager.Instance.chestSpaces.Add(extraChest.GetComponent<Transform>());
            }
            itemDetails.amountInStack--;
            Destroy(gameObject);
            

        }
        
    }
}
