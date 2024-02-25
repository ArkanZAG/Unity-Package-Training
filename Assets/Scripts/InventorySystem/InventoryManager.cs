using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [FormerlySerializedAs("items")] public List<Item> inventory = new List<Item>();

    [FormerlySerializedAs("itemContent")] public Transform itemElementUiHolder;
    [FormerlySerializedAs("inventoryItem")] public GameObject inventoryElementPrefab;

    public Toggle enableRemove;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        inventory.Add(item);
    }

    public void Remove(Item item)
    {
        inventory.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform element in itemElementUiHolder)
        {
            Destroy(element.gameObject);
        }

        foreach (var item in inventory)
        {
            GameObject obj = Instantiate(inventoryElementPrefab, itemElementUiHolder);
            InventoryElement element = obj.GetComponent<InventoryElement>();
            
            TextMeshProUGUI itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();
            Button removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            
            element.SetItem(item);

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if (enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
    }

    public void EnableItemsRemove()
    {
        if (enableRemove.isOn)
        {
            foreach (Transform item in itemElementUiHolder)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemElementUiHolder)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
