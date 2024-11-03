using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    List<Item> _itemsList;


    public Item GetItem(int idItem)
    {
        return _itemsList[idItem];
    }
}
