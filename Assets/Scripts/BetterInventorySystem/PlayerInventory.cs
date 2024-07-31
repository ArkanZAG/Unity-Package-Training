using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace BetterInventorySystem
{
    public class PlayerInventory : Inventory
    {
        [SerializeField] private PlayerStats stats;
        
        private void Awake()
        {
            Debug.Log("Subs to OnPickedUp Function");
            ItemPickup.OnPickedUp.AddListener(OnPickedUp);
        }

        private void OnPickedUp(ItemPickup pickedUp)
        {
            Debug.Log("OnPickedUp Function Called");
            AddItem(pickedUp.Item);
            Destroy(pickedUp.gameObject);
        }

        public override void UseItem(int index)
        {
            var item = items[index];
            stats.ExecuteItemEffect(item);
            RemoveItem(index);
        }

    }
}