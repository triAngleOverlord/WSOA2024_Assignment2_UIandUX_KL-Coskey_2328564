using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float moneyNow;
    public static int moneyToBuy;

    

    public POPUPDetails[] _PopUpDetails;

    public GameObject itemPopUp_B;
    public GameObject itemPopUp_S;

    public GameObject soldoutPopUp;
    public GameObject slotUpgrade;
    public GameObject pocketUpgrade;

    
    public List<Transform> chestSpaces;
    
    public List<Transform> _backPackPockets;
    public static float backPackSpace;
    public static int pockets;

    public static float shopClicks;
    public List<Transform> shopItems;

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
        pocketUpgrade = Resources.Load<GameObject>("ItemSlot_Back");
        backPackSpace = 3;
        shopClicks = 0;

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

        foreach (Transform itemChild in GameObject.Find("Slots_Shop").transform)
        {
            shopItems.Add(itemChild.transform);
            itemChild.gameObject.SetActive(false);
        }

        foreach (Transform pocketChild in GameObject.Find("BackpackSlots").transform)
        {
            _backPackPockets.Add(pocketChild.transform);
            pocketChild.gameObject.SetActive(false);
        }

        for(int i =0; i <3;  i++)
        {
            _backPackPockets[i].gameObject.SetActive(true);
        }
        pockets = 2;

        


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


    

}
