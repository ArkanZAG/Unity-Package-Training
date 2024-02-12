using TMPro;
using UnityEngine;

namespace BetterInventorySystem
{
    public class PlayerStats : MonoBehaviour
    {
        //DEBUG
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI expText;
        public int health, exp;
        
        public void ExecuteItemEffect(Item item)
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