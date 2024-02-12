using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BetterInventorySystem
{
    public class Inventory : MonoBehaviour
    {
        protected List<Item> items = new();

        public IReadOnlyList<Item> Items => items;

        public UnityEvent<Inventory> onUpdated = new();

        protected void RemoveItem(int itemIndex)
        {
            items.RemoveAt(itemIndex);
            onUpdated?.Invoke(this);
        }

        protected void AddItem(Item item)
        {
            items.Add(item);
            Debug.Log("ITEMS ADDED");
            onUpdated?.Invoke(this);
        }
        
        public virtual void UseItem(int index) {}
    }
}