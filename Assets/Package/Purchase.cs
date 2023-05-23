using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    public ItemDetails itemDetails;
    public string itemName;
    public float price;
    public float amountLeft;

    public GameObject itemButton;
    //public BoughtItem boughtItem;



    /*
        private void Update()
        {
            itemName = GameManager.c_itemName;
            price = GameManager.c_itemPrice;
            amountLeft = GameManager.c_itemAmount;
        }*/

    public void buyWithPrice()
    {
        itemName = itemDetails.itemName;
        price = itemDetails.buyingPrice;
        amountLeft = itemDetails.amountInShop;
        

        var c_value = GameObject.Find("Slider").GetComponent<Slider>().value;
        float enoughMoney = GameManager.moneyNow - (price * c_value);
        //GameObject.Find("Avaliable").GetComponent<TextMeshProUGUI>().text = new string(amountLeft.ToString());

        if (enoughMoney > 0 || enoughMoney == 0 )
        {
            GameManager.moneyNow = enoughMoney;
            amountLeft = amountLeft - c_value;
            Debug.Log("Just bought " + c_value + "x " +itemName + " for only $" + price * c_value);

            GameObject.Find("Slider").GetComponent<Slider>().value = 1;
            itemDetails.amountInShop = amountLeft;
            //GameManager.c_itemAmount = amountLeft;
            //Debug.Log(amountLeft + " gm says:" + GameManager.c_itemAmount);

            //GameObject.Find(itemName).GetComponent<POPUPDetails>().amountLeft = GameManager.c_itemAmount;

            GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = GameManager.moneyNow.ToString();
            GameObject.Find("AvaliableStock").GetComponent<TextMeshProUGUI>().text = new string(amountLeft.ToString());
            GameObject.Find("Slider").GetComponent<Slider>().maxValue = amountLeft;
            GameObject.Find("ItemClicked").SetActive(false);
            
            gameObject.GetComponent<BoughtItem>()._item = itemDetails.itemObject;
            gameObject.GetComponent<BoughtItem>().itemIntoBag();
        }

        else
        {
            Debug.Log("You do not have enough money to make this purchase");
        }

        
        checkItemStock();

    }


    public void sliderAmount()
    {
        //amountLeft = itemDetails.amountInShop;
        price = itemDetails.buyingPrice;
        
        var c_value = GameObject.Find("Slider").GetComponent<Slider>().value;
        GameObject.Find("NumberItems").GetComponent<TextMeshProUGUI>().text = new string(c_value.ToString());
        GameObject.Find("TotalPrice").GetComponent<TextMeshProUGUI>().text = new string("$"+(c_value*price).ToString());

    }

    public void checkItemStock()
    {
        if (amountLeft == 0)
        {
            //GameObject parent= GameObject.Find(itemDetails.itemName);
            GameObject soldSign = Instantiate(GameManager.Instance.soldoutPopUp);
            //soldSign.transform.localScale = Vector3.one;
            soldSign.transform.localPosition = itemButton.transform.position;
            itemButton.GetComponent<Button>().enabled = false;
        }
    }

}
