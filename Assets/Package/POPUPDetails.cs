using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class POPUPDetails : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] public float price;
    [SerializeField] public float amountLeft;

    public ItemDetails itemDetails;


    public Purchase buyStuff;
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
        //itemDetails = transform.GetComponent<BoughtItem>().itemDetails;
        //popUpThing.transform.SetParent(transform);
        Vector3 popUpPos = transform.position;
        popUpPos.x = 2;
        popUpThing.transform.position = popUpPos;
        //GameObject.Find("Slider").GetComponent<Slider>().value = 1;

        //buyStuff = GameObject.Find("BuyButton").GetComponent<BuyingPopUp>();
        amountLeft = itemDetails.amountInShop;
        price = itemDetails.buyingPrice;

        //GameManager.c_itemName = transform.name;
        //GameManager.c_itemPrice = price;
        //GameManager.c_itemAmount = amountLeft;

        GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = new string(transform.name);

        GameObject.Find("Slider").GetComponent<Slider>().maxValue = amountLeft;
        GameObject.Find("Slider").GetComponent<Slider>().value = 1;
        GameObject.Find("Slider").GetComponent<Purchase>().itemDetails = itemDetails;

        GameObject.Find("ConfirmPurchase").GetComponent<Purchase>().itemDetails = itemDetails;
        GameObject.Find("ConfirmPurchase").GetComponent<Purchase>().itemButton = this.gameObject;

        GameObject.Find("TotalPrice").GetComponent<TextMeshProUGUI>().text = new string("-$"+ price.ToString());
        GameObject.Find("AvaliableStock").GetComponent<TextMeshProUGUI>().text = new string (amountLeft.ToString());
        transform.GetComponent<BoughtItem>().itemDetails = itemDetails;




    }

    public void cancel()
    {
        popUpThing.SetActive(false);
    }


    
}
