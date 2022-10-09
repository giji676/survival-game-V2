using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    #region Singleton

    public static Hotbar instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of hotbar found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 6;
    public List<Item> items = new List<Item>();

    private int activeSlot = -1;

    public bool Add(Item item)
    {
        if (items.Count < inventorySpace)
        {
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            return true;
        }

        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void UseSlot(int slot)
    {
        if (slot < items.Count)
        {
            Item item = items[slot];
            if (slot == activeSlot)
            {
                item.StopUse();
                activeSlot = -1;
            }

            else if (item.itemType == ItemType.Tool || item.itemType == ItemType.Weapon)
            {
                if (activeSlot != -1)
                {
                    items[activeSlot].StopUse();
                }

                activeSlot = slot;
                item.Use();
            }

            else if (item.itemType == ItemType.Armor)
            {
                if (Armor.instance.Add(item))
                {
                    Remove(item);
                }
            }
        }
    }
}
