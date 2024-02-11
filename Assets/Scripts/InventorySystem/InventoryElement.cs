using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    private Item item;

    public Button RemoveButton;
    
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        
        Destroy(gameObject);
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                Player.instance.IncreaseHealth(item.value);
                break;
            case Item.ItemType.Book:
                Player.instance.IncreaseExp(item.value);
                break;
        }
        
        RemoveItem();
    }
}
