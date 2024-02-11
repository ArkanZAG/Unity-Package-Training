using UnityEngine;

namespace BetterInventorySystem
{
    public class DisplayPlayerInventoryButton : MonoBehaviour
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private InventoryView view;

        public void Display()
        {
            view.Display(playerInventory.Inventory, OnClicked);
        }

        private void OnClicked(int index)
        {
            playerInventory.UseItem(index);
        }
    }
}