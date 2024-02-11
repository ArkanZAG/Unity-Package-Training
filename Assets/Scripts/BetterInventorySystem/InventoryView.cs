using System;
using System.Collections.Generic;
using UnityEngine;

namespace BetterInventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject elementPrefab;
        [SerializeField] private Transform parent;
        
        private List<InventoryElement> spawnedElements = new();

        public void Display(List<Item> inventory, Action<int> onItemClicked)
        {
            foreach (InventoryElement element in spawnedElements)
            {
                Destroy(element.gameObject);
            }

            for (var index = 0; index < inventory.Count; index++)
            {
                var item = inventory[index];
                GameObject obj = Instantiate(elementPrefab, parent);
                var element = obj.GetComponent<InventoryElement>();
                element.Display(item, index, onItemClicked);
            }
        }
    }
}