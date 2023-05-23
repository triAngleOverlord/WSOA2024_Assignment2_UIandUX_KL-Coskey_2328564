using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDetails : ScriptableObject
{
    [SerializeField] public float sellingPrice;
    [SerializeField] public float buyingPrice;
    [SerializeField] public string itemName;
    [SerializeField] public float amountInShop;

    public float amountInStack;
    

    public void Awake()
    {
        amountInShop = 0;
    }
}
