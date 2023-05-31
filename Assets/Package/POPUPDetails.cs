using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class POPUPDetails : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] public float price;
    [SerializeField] public float amountLeft;

    public ItemDetails itemDetails;


    //public Purchase buyStuff;
    public GameObject popUpThing;


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
        Vector3 popUpPos = transform.position;
        popUpPos.x = 2;
        popUpThing.transform.position = popUpPos;
        
        amountLeft = itemDetails.amountInShop;
        price = itemDetails.buyingPrice;


        GameObject.Find("ItemName_B").GetComponent<TextMeshProUGUI>().text = new string(transform.name);

        GameObject.Find("Slider_B").GetComponent<Slider>().maxValue = amountLeft;
        GameObject.Find("Slider_B").GetComponent<Slider>().value = 1;
        GameObject.Find("Slider_B").GetComponent<Purchase>().itemDetails = itemDetails;

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
