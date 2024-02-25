using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BetterInventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private RectTransform holder;
        [SerializeField] private GameObject elementPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private Button closeButton;
        
        private List<InventoryElement> spawnedElements = new();
        private Inventory currentInventory;

        private void Awake()
        {
            closeButton.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            CleanInventory();
            
            holder.gameObject.SetActive(false);
        }

        public void CleanInventory()
        {
            if (currentInventory == null) return;
            currentInventory.onUpdated.RemoveListener(Display);
            currentInventory = null;
        }
        
        public void Display(Inventory inventory)
        {
            Debug.Log("WILL DISPLAY");
            CleanInventory();
            
            currentInventory = inventory;
            currentInventory.onUpdated.AddListener(Display);
            holder.gameObject.SetActive(true);

            CleanObjects();

            for (var index = 0; index < inventory.Items.Count; index++)
            {
                var item = inventory.Items[index];
                GameObject obj = Instantiate(elementPrefab, parent);
                InventoryElement element = obj.GetComponent<InventoryElement>();
                element.Display(item, index, inventory.UseItem);
                spawnedElements.Add(element);
            }
        }

        private void CleanObjects()
        {
            foreach (InventoryElement element in spawnedElements)
            {
                Destroy(element.gameObject);
            }
            
            spawnedElements.Clear();
        }
    }
}