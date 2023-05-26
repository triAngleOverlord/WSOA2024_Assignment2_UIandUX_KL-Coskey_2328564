using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    public ItemDetails itemDetails;
    public string itemName;
    public float price;
    public float amountLeft;
    public GameObject _itemObject;

    public GameObject itemButton;
    
    public void buyWithPrice()
    {
        itemName = itemDetails.itemName;
        price = itemDetails.buyingPrice;
        amountLeft = itemDetails.amountInShop;
        _itemObject = itemDetails.itemObject;

        
        GameObject existingItemSlot = GameObject.FindGameObjectWithTag(_itemObject.tag);
        //GameObject.Find("Avaliable").GetComponent<TextMeshProUGUI>().text = new string(amountLeft.ToString());

        if (existingItemSlot != null)
        {
            makePurchase();

        }
        else if (GameManager.backPackSpace!= 0)
        {
            makePurchase();
        }
        else
        {
            Debug.Log("You don't have anymore backpack space");
        }
        
        checkItemStock();

    }


    public void sliderAmount()
    {
        //amountLeft = itemDetails.amountInShop;
        price = itemDetails.buyingPrice;
        
        var c_value = GameObject.Find("Slider_B").GetComponent<Slider>().value;
        GameObject.Find("NumberItems").GetComponent<TextMeshProUGUI>().text = new string(c_value.ToString());
        GameObject.Find("TotalPrice").GetComponent<TextMeshProUGUI>().text = new string("-$"+(c_value*price).ToString());

        if (c_value == 0)
        {
            GameObject.Find("Slider_B").GetComponent<Slider>().value = 1;
        }

    }

    public void checkItemStock()
    {
        if (amountLeft == 0)
        {
            GameObject parent= GameObject.Find(itemDetails.itemName);
            GameObject soldSign = Instantiate(GameManager.Instance.soldoutPopUp);
            soldSign.transform.SetParent(parent.transform, true);
            //soldSign.transform.localScale = Vector3.one;
            soldSign.transform.localPosition = Vector3.zero;
            itemButton.GetComponent<Button>().enabled = false;
        }
    }

    public void makePurchase()
    {
        BoughtItem bought = GameObject.Find(itemName).GetComponent<BoughtItem>();


        var c_value = GameObject.Find("Slider_B").GetComponent<Slider>().value;
        float enoughMoney = GameManager.moneyNow - (price * c_value);
        if (enoughMoney > 0 || enoughMoney == 0)
        {
            GameManager.moneyNow = enoughMoney;
            amountLeft = amountLeft - c_value;
            Debug.Log("Just bought " + c_value + "x " + itemName + " for only $" + price * c_value);

            GameObject.Find("Slider_B").GetComponent<Slider>().value = 1;
            itemDetails.amountInShop = amountLeft;

            GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = GameManager.moneyNow.ToString();
            GameObject.Find("AvaliableStock").GetComponent<TextMeshProUGUI>().text = new string(amountLeft.ToString());
            GameObject.Find("Slider_B").GetComponent<Slider>().maxValue = amountLeft;
            GameObject.Find("ItemClicked_BUY").SetActive(false);

            bought.valueSelected = c_value;
            bought.itemIntoBag();
        }

        else
        {
            Debug.Log("You do not have enough money to make this purchase");
        }

    }

}
