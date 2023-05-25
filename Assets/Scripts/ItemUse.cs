using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public float amountStack;
    public float _sellPrice;

    public GameObject sellingItem;

    public ItemDetails itemDetails;

    //public Purchase buyStuff;
    public GameObject popUpThing;


    public void thisItemToSell()
    {
        if (popUpThing.activeSelf == false)
        {
            popUpThing.SetActive(true);
            setPopUp_Sell();

        }

        else
        {
            setPopUp_Sell();
        }


    }

    public void setPopUp_Sell()
    {
        popUpThing = GameObject.Find("ItemClicked_SELL");
        //itemDetails = transform.GetComponent<BoughtItem>().itemDetails;
        //popUpThing.transform.SetParent(transform);
        Vector3 popUpPos = transform.position;
        popUpPos.x = -2;
        popUpThing.transform.position = popUpPos;
        //popUpThing.transform.localPosition = Vector3.right * 200;
        //GameObject.Find("Slider").GetComponent<Slider>().value = 1;

        //buyStuff = GameObject.Find("BuyButton").GetComponent<BuyingPopUp>();
        amountStack = GetComponent<ItemMouseEvents>().amountStack;
        _sellPrice = itemDetails.sellingPrice;

        //GameManager.c_itemName = transform.name;
        //GameManager.c_itemPrice = price;
        //GameManager.c_itemAmount = amountLeft;

        GameObject.Find("ItemName_S").GetComponent<TextMeshProUGUI>().text = new string("Sell "+itemDetails.itemName);
        GameObject.Find("Slider_S").GetComponent<Slider>().maxValue = amountStack;
        GameObject.Find("Slider_S").GetComponent<Slider>().value = 1;
        GameObject.Find("Slider_S").GetComponent<ItemUse>().itemDetails = itemDetails;
        GameObject.Find("ConfirmSell").GetComponent<ItemUse>().itemDetails = itemDetails;
        GameObject.Find("ConfirmSell").GetComponent<ItemUse>().sellingItem = this.gameObject;
        GameObject.Find("ConfirmSell").GetComponent<ItemUse>().amountStack = amountStack;
        GameObject.Find("TotalGain").GetComponent<TextMeshProUGUI>().text = new string("+$" + _sellPrice.ToString());
        GameObject.Find("SellStackAmount").GetComponent<TextMeshProUGUI>().text = new string(amountStack.ToString());
        GameObject.Find("NumberItemsToSell").GetComponent<TextMeshProUGUI>().text = new string("1");




    }

    public void sellItem()
    {
        cancel();
        //Destroy(sellingItem);
        

        var c_value = GameObject.Find("Slider_S").GetComponent<Slider>().value;
        sellingItem.GetComponent<ItemMouseEvents>().amountStack -= c_value;
        sellingItem.gameObject.transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(sellingItem.GetComponent<ItemMouseEvents>().amountStack.ToString());
        GameManager.moneyNow += c_value * itemDetails.sellingPrice;
        GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = GameManager.moneyNow.ToString();
        UnityEngine.Debug.Log(itemDetails.itemName +"x "+c_value+" was sold for $" + c_value * itemDetails.sellingPrice);
        checkItemStack();
        backToShop(c_value);


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
            //itemDetails.amountInStack--;
            gameObject.transform.parent.transform.tag = "Avaliable";
            GameManager.backPackSpace++;
            Destroy(gameObject);
            
        }
    }
    public void sliderAmount()
    {
        //amountLeft = itemDetails.amountInShop;
        _sellPrice = itemDetails.sellingPrice;

        var c_value = GameObject.Find("Slider_S").GetComponent<Slider>().value;
        GameObject.Find("NumberItemsToSell").GetComponent<TextMeshProUGUI>().text = new string(c_value.ToString());
        GameObject.Find("TotalGain").GetComponent<TextMeshProUGUI>().text = new string("+$" + (c_value * _sellPrice).ToString());

        if (c_value == 0)
        {
            GameObject.Find("Slider_S").GetComponent<Slider>().value = 1;
        }

    }

    public void checkItemStack()
    {
        if (sellingItem.GetComponent<ItemMouseEvents>().amountStack == 0)
        {
            sellingItem.transform.parent.tag = "Avaliable";

            if (sellingItem.transform.parent.transform.parent.name =="BackpackSlots")
            {
                GameManager.backPackSpace++;
                UnityEngine.Debug.Log(GameManager.backPackSpace);
                UnityEngine.Debug.Log(sellingItem.transform.parent.transform.parent.name);
            }
            Destroy(sellingItem);
        }
    }

    public void cancel()
    {
        popUpThing.transform.position = Vector3.one * 10;
    }

    public void backToShop(float value)
    {
        if (itemDetails.amountInShop == 0)
        {
            
            GameObject soldsign = GameObject.Find("Slots_Shop").transform.Find(itemDetails.itemName).transform.Find("SOLDOUT(Clone)").gameObject;
            UnityEngine.Debug.Log(soldsign.name);
            GameObject.Find("Slots_Shop").transform.Find(itemDetails.itemName).transform.GetComponent<Button>().enabled = true;
            Destroy(soldsign);

        }
        itemDetails.amountInShop += value;
    }

    public void sewMorePockets()
    {
        for (int i = GameManager.pockets+1; i < GameManager.pockets+4; i++)
        {
            /*
            GameObject extraPocket = Instantiate(GameManager.Instance.pocketUpgrade);
            extraPocket.transform.SetParent(GameObject.Find("BackpackSlots").transform);
            extraPocket.transform.localScale = Vector3.one;
            GameManager.Instance._backPackPockets.Add(extraPocket.GetComponent<Transform>());
            */
            GameManager.Instance._backPackPockets[i].gameObject.SetActive(true);
            GameManager.backPackSpace++;
            
        }
        GameManager.pockets += 3;
        //itemDetails.amountInStack--;
        gameObject.GetComponent<ItemMouseEvents>().amountStack--;
        transform.Find("Circle").gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = new string(transform.GetComponent<ItemMouseEvents>().amountStack.ToString());
            

        if (gameObject.GetComponent<ItemMouseEvents>().amountStack == 0)
        {
            gameObject.transform.parent.transform.tag = "Avaliable";
            GameManager.backPackSpace++;
            Destroy(gameObject);

        }
        
    }
    
}
