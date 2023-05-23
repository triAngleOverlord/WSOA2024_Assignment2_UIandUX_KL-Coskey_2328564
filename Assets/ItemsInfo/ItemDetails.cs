using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDetails : ScriptableObject
{
    public float sellingPrice;
    public float buyingPrice;

    public float amountInStack;
    public float amountInShop;
}
