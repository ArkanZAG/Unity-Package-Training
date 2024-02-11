using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BetterInventorySystem
{
    public class InventoryElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private int index;
        private Action<int> onButtonClicked;

        private void Awake()
        {
            button.onClick.AddListener(OnClicked);
        }

        public void Display(Item item, int elementIndex, Action<int> onClicked)
        {
            nameText.text = item.itemName;
            icon.sprite = item.icon;
            onButtonClicked = onClicked;
            index = elementIndex;
        }

        public void OnClicked()
        {
            onButtonClicked?.Invoke(index);
        }
    }
}