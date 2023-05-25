using UnityEngine;

[CreateAssetMenu]
public class ItemDetails : ScriptableObject
{
    [SerializeField] public string itemName;

    [SerializeField] public float buyingPrice;
    [SerializeField] public float sellingPrice;
    
    
    [SerializeField] public float stockAmount;
    [SerializeField] public GameObject itemObject;

    [Header("Changing Variables")]
    public float amountInShop;

    public void Start()
    {
        amountInShop = stockAmount;
        

    }
}
