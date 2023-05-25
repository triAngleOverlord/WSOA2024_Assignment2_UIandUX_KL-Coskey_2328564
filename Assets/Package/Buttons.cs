using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject p_Backpack;
    public GameObject p_Shop;
    public GameObject p_Chest;
    public GameObject p_Pop;
    public GameObject p_Outside;
    public GameObject b_Return;
    public float c_Money;

    private void Awake()
    {
        p_Backpack = GameObject.Find("BACKPACK");
        p_Shop = GameObject.Find("SHOP");
        p_Chest = GameObject.Find("CHEST");
        p_Pop = GameObject.Find("ItemClicked_BUY");
        p_Outside = GameObject.Find("OUTSIDE");
        b_Return = GameObject.Find("Return");



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
        b_Return.SetActive(true);
        p_Outside.SetActive(false);

        p_Shop.SetActive(false);

        p_Chest.SetActive(true);
        p_Chest.GetComponent<RectTransform>().transform.localPosition = Vector3.left * 470;

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.right * 470;


    }

    public void openTheShop()
    {
        b_Return.SetActive(true);
        p_Outside.SetActive(false);
        if (p_Pop != false)
        {
            p_Pop.SetActive(false);
        }

        p_Chest.SetActive(false);

        p_Shop.SetActive(true);
        p_Shop.GetComponent<RectTransform>().transform.localPosition = Vector3.left * 470;

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.right * 470;

        /*
        c_Money--;
        GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text = new string(c_Money.ToString());
        GameManager.moneyNow = c_Money;
        Debug.Log("Purchase made with money left:" +  c_Money.ToString());
        */
    }

    public void openTheBackpack()
    {
        p_Outside.SetActive(false);
        b_Return.SetActive(true);

        p_Chest.SetActive(false);

        p_Shop.SetActive(false);

        p_Backpack.SetActive(true);
        p_Backpack.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;

    }

    public void goOutside()
    {
        p_Outside.SetActive(true);
        b_Return.SetActive(false);

        p_Backpack.SetActive(false );
        p_Chest.SetActive(false);
        p_Shop.SetActive(false);

    }

}
