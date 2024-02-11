using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace BetterInventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        //DEBUG
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI expText;
        public int health, exp;
        
        private List<Item> inventory = new();

        public List<Item> Inventory => inventory;

        private void RemoveItem(int itemIndex)
        {
            inventory.RemoveAt(itemIndex);
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void UseItem(int index)
        {
            var item = inventory[index];
            ExecuteItemEffect(item);
            RemoveItem(index);
        }

        private void ExecuteItemEffect(Item item)
        {
            switch (item.itemType)
            {
                case Item.ItemType.Potion:
                    health += item.value;
                    healthText.text = $"HP:{health}";
                    break;
                case Item.ItemType.Book:
                    exp += item.value;
                    expText.text = $"EXP:{exp}";
                    break;
            }
        }
    }
}