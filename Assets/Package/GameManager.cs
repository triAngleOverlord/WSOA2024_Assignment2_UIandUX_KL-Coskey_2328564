using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float moneyNow;
    public static int moneyToBuy;

    
    //public static string c_itemName;
    //public static float c_itemPrice;
    //public static float c_itemAmount;

    //public static int itemStackNum;

    public POPUPDetails[] _PopUpDetails;

    public GameObject itemPopUp_B;
    public GameObject itemPopUp_S;

    public GameObject soldoutPopUp;
    public GameObject slotUpgrade;

    //public ChestSpaces spaces;
    public List<Transform> chestSpaces;
    public static int currentChestSpace;
    public static float backPackSpace;

    public ItemDetails[] _itemDetails;


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance=this;
        }

        moneyNow = 100;

        itemPopUp_B = GameObject.Find("ItemClicked_BUY");
        itemPopUp_S = GameObject.Find("ItemClicked_SELL");
        soldoutPopUp = Resources.Load<GameObject>("SOLDOUT");
        slotUpgrade = Resources.Load<GameObject>("ItemSlot");
        backPackSpace = 9;

        _PopUpDetails =GameObject.FindObjectsByType<POPUPDetails>(FindObjectsSortMode.InstanceID);
        for (int i = 0; i < _PopUpDetails.Length; i++)
        {
            _PopUpDetails[i].popUpThing = itemPopUp_B;
        }

            //FindAnyObjectByType<ItemDetails>().popUpThing = itemPopUp;
        itemPopUp_B.SetActive(false);
        
        foreach (Transform child in GameObject.Find("Slots_Chest").transform)
        {
            chestSpaces.Add(child.transform);
        }
                    //Resources.Load<GameObject>("ItemClicked");


        //itemPopUp = Resources.Load<GameObject>("ItemClicked");


        ///gives the popup and soldout objects to every item's buy button at beginning in order to instantiate later
        //itemPopUp = GameObject.Find("ItemClicked");
        
        //chestContainer = Resources.Load<GameObject>("Container_Chest");

        /*
        //spaces = new ChestSpaces();
        chestSpaces = new List<GameObject>();
        GameObject extraChest = Instantiate(chestContainer, GameObject.Find("Chest").transform);
        chestSpaces.Add(extraChest);
        GameObject.Find("PreviousPageChest").GetComponent<ChestButtons>().chestContainer = chestContainer;
        //Debug.Log(GameObject.Find("PreviousPageChest").gameObject.name);
        Debug.Log( chestSpaces[currentChestSpace].gameObject.name);*/

        /*
        buy =GameObject.FindObjectsByType<BuyButton>(FindObjectsSortMode.InstanceID);
        for (int i = 0; i < buy.Length; i++)
        {
            buy[i].popUpThing = itemPopUp;
            buy[i].soldPopUp = soldoutPopUp;
        }*/

        //itemPopUp.SetActive(false);

        //currentChestSpace = 0;
        

        //Resources.Load<GameObject>("ItemClicked");

        //Debug.Log(itemPopUp.name);

        _itemDetails = Resources.LoadAll<ItemDetails>("ItemsInfo");
        for (int i= 0; i < _itemDetails.Length;i++)
        {
            _itemDetails[i].Start();
        }


    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    /*
    public void chestUpgrade(GameObject chest)
    {
        chestSpaces.Add(chest);
        //GameObject extraChest = Instantiate(chest, GameObject.Find("Chest").transform);
        //chestSpaces.Add(extraChest);
        
        //extraChest.SetActive(false);
        Debug.Log(chestSpaces[currentChestSpace].gameObject.name);
    }*/

}
