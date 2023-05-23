using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestButtons : MonoBehaviour
{
    public GameObject chestContainer;
    public List<GameObject> chest;

    public void chestUpgrade()
    {
        chest = new List<GameObject>();
        //chest= GameManager.Instance.chestSpaces;
        GameObject extraChest = Instantiate(chestContainer, GameObject.Find("Chest").transform);
        chest.Add( extraChest);
        extraChest.SetActive(false);
        //GameManager.Instance.chestUpgrade(extraChest);
        
        
        //GameManager.Instance.chestUpgrade(chestContainer);
    }

    public void nextChest()
    {
        
    }
}
