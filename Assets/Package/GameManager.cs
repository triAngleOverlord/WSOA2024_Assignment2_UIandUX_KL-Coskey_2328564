using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float moneyNow;
    public static int moneyToBuy;

    
    public static string c_itemName;
    public static float c_itemPrice;
    public static float c_itemAmount;

    //public static int itemStackNum;

    public POPUPDetails[] _PopUpDetails;

    public GameObject itemPopUp;

    public GameObject soldoutPopUp;
    public GameObject chestContainer;

    //public ChestSpaces spaces;
    public List<GameObject> chestSpaces;
    public static int currentChestSpace;

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

        itemPopUp = GameObject.Find("ItemClicked");
        soldoutPopUp = Resources.Load<GameObject>("SOLDOUT");

        _PopUpDetails =GameObject.FindObjectsByType<POPUPDetails>(FindObjectsSortMode.InstanceID);
        for (int i = 0; i < _PopUpDetails.Length; i++)
        {
            _PopUpDetails[i].popUpThing = itemPopUp;
        }

            //FindAnyObjectByType<ItemDetails>().popUpThing = itemPopUp;
        itemPopUp.SetActive(false);
        
                    //Resources.Load<GameObject>("ItemClicked");


        //itemPopUp = Resources.Load<GameObject>("ItemClicked");


        ///gives the popup and soldout objects to every item's buy button at beginning in order to instantiate later
        //itemPopUp = GameObject.Find("ItemClicked");
        
        chestContainer = Resources.Load<GameObject>("Container_Chest");

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

        itemPopUp.SetActive(false);

        currentChestSpace = 0;

        //Resources.Load<GameObject>("ItemClicked");

        //Debug.Log(itemPopUp.name);

        _itemDetails = Resources.LoadAll<ItemDetails>("ItemsInfo");
        for (int i= 0; i < _itemDetails.Length;i++)
        {
            _itemDetails[i].Start();
        }


    }

    
    

    public void chestUpgrade(GameObject chest)
    {
        chestSpaces.Add(chest);
        //GameObject extraChest = Instantiate(chest, GameObject.Find("Chest").transform);
        //chestSpaces.Add(extraChest);
        
        //extraChest.SetActive(false);
        Debug.Log(chestSpaces[currentChestSpace].gameObject.name);
    }

}
