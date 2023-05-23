using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDetails : ScriptableObject
{
    [SerializeField] public float sellingPrice;
    [SerializeField] public float buyingPrice;

    public float amountInStack;
    [SerializeField] public float amountInShop;

    public void Awake()
    {
        amountInShop = 0;
    }
}
