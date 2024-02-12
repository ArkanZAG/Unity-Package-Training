using System;
using UnityEngine;
using UnityEngine.UI;

namespace BetterInventorySystem
{
    public class DisplayPlayerInventoryButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private InventoryView view;

        private void Awake()
        {
            button.onClick.AddListener(Display);
        }

        public void Display()
        {
            view.Display(playerInventory);
        }
    }
}