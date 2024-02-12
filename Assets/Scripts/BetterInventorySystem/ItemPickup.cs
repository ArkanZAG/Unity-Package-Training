using System;
using UnityEngine;
using UnityEngine.Events;

namespace BetterInventorySystem
{
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private Item item;

        public Item Item => item;

        public static UnityEvent<ItemPickup> OnPickedUp = new();

        private void OnMouseDown()
        {
            OnPickedUp?.Invoke(this);
        }
    }
}