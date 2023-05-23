using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class POPUPDetails : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] public float price;
    [SerializeField] public float amountLeft;

    public ItemDetails itemDetails;

    public BuyingPopUp buyStuff;
    public GameObject popUpThing;

    /*
    private void Start()
    {
        popUpThing = GameObject.Find("ItemClicked");

        if (popUpThing != null )
        {
            popUpThing.SetActive(false);
        }
        
    }*/

    public void thisItemSelected()
    {
        if (popUpThing.activeSelf == false )
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
        popUpThing.transform.SetParent(transform);
        popUpThing.transform.localPosition = Vector3.right * 50;
        //GameObject.Find("Slider").GetComponent<Slider>().value = 1;

        //buyStuff = GameObject.Find("BuyButton").GetComponent<BuyingPopUp>();
        amountLeft = itemDetails.amountInShop;
        price = itemDetails.buyingPrice;

        //GameManager.c_itemName = transform.name;
        //GameManager.c_itemPrice = price;
        //GameManager.c_itemAmount = amountLeft;

        GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = new string(transform.name);
        GameObject.Find("Slider").GetComponent<Slider>().maxValue = amountLeft;
        

    }

    public void cancel()
    {
        popUpThing.SetActive(false);
    }


    
}
