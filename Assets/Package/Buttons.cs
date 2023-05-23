using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject p_Backpack;
    public GameObject p_Shop;
    public GameObject p_Chest;
    public GameObject p_Pop;
    public float c_Money;

    private void Awake()
    {
        p_Backpack = GameObject.Find("Backpack");
        p_Shop = GameObject.Find("Shop");
        p_Chest = GameObject.Find("Chest");
        p_Pop = GameObject.Find("ItemClicked");



        c_Money = GameManager.moneyNow;


    }

    private void Start()
    {

        ///only the backpack is open at the beginning
        //openTheBackpack();

        goOutside();

    }

    public void openTheChest()
    {
        p_Shop.SetActive(false);

        p_Chest.SetActive(true);
        p_Chest.GetComponent<RectTransform>().transform.localPosition = Vector3.left * 190;

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.right * 190;


    }

    public void openTheShop()
    {
        if (p_Pop != false)
        {
            p_Pop.SetActive(false);
        }

        p_Chest.SetActive(false);

        p_Shop.SetActive(true);
        p_Shop.GetComponent<RectTransform>().transform.localPosition = Vector3.left * 190;

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.right * 190;

        /*
        c_Money--;
        GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = new string(c_Money.ToString());
        GameManager.moneyNow = c_Money;
        Debug.Log("Purchase made with money left:" +  c_Money.ToString());
        */
    }

    public void openTheBackpack()
    {
        p_Chest.SetActive(false);

        p_Shop.SetActive(false);

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;

    }

    public void goOutside()
    {

    }

}
