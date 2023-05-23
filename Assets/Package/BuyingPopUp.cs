using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingPopUp : MonoBehaviour
{
    public string itemName;
    public float price;
    public float amountLeft;


    private void Update()
    {
        itemName = GameManager.c_itemName;
        price = GameManager.c_itemPrice;
        amountLeft = GameManager.c_itemAmount;
    }

    public void buyWithPrice()
    {
        GameManager.c_itemName= itemName;
        GameManager.c_itemPrice= price;
        GameManager.c_itemAmount= amountLeft;
       /*
       Debug.Log(price);
       Debug.Log(itemName);
       Debug.Log(amountLeft);
       */

        var c_value = GameObject.Find("Slider").GetComponent<Slider>().value;
        float enoughMoney = GameManager.moneyNow - price * c_value;
        GameObject.Find("Avaliable").GetComponent<TextMeshProUGUI>().text = new string(amountLeft.ToString());

        if (enoughMoney > 0 || enoughMoney == 0 )
        {
            GameManager.moneyNow = enoughMoney;
            amountLeft = amountLeft - c_value;
            Debug.Log("Just bought " + c_value + "x " +itemName + " for only $" + price * c_value);

            GameObject.Find("Slider").GetComponent<Slider>().value = 1;
            GameManager.c_itemAmount = amountLeft;
            //Debug.Log(amountLeft + " gm says:" + GameManager.c_itemAmount);

            GameObject.Find(itemName).GetComponent<POPUPDetails>().amountLeft = GameManager.c_itemAmount;

            GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = GameManager.moneyNow.ToString();

            

        }

        else
        {
            Debug.Log("You do not have enough money to make this purchase");
        }

        


    }


    public void showAmountItems()
    {
        GameObject.Find("Slider").GetComponent<Slider>().maxValue = amountLeft;
        var c_value = GameObject.Find("Slider").GetComponent<Slider>().value;
        GameObject.Find("NumberItems").GetComponent<TextMeshProUGUI>().text = new string(c_value.ToString());
        GameObject.Find("Price").GetComponent<TextMeshProUGUI>().text = new string("$"+(c_value*price).ToString());

    }

}
