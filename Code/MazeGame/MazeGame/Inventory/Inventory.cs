using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    // 1号格子
    public List<ItemData> Items1 { get; set; } = new List<ItemData>();
    // 2号格子
    public List<ItemData> Items2 { get; set; } = new List<ItemData>();
    // 3号格子
    public List<ItemData> Items3 { get; set; } = new List<ItemData>();
    public event Action Changed;

    public Inventory()
    {

    }

    //背包添加物品
    public bool AddItem(ItemData item)
    {
        // 先尝试堆叠到同类型且未满的槽位，再放入空槽。
        if (TryAddToSlot(Items1, item) || TryAddToSlot(Items2, item) || TryAddToSlot(Items3, item))
        {
            NotifyChanged();
            return true;
        }

        return false;
    }

    //背包使用物品
    public void UseItem(int slot)
    {
        if (slot < 1 || slot > 3)
            return;

        bool removed = false;
        switch (slot)
        {
            case 1:
                if (Items1.Count > 0)
                {
                    Items1.RemoveAt(Items1.Count - 1);
                    removed = true;
                }
                break;
            case 2:
                if (Items2.Count > 0)
                {
                    Items2.RemoveAt(Items2.Count - 1);
                    removed = true;
                }
                break;
            case 3:
                if (Items3.Count > 0)
                {
                    Items3.RemoveAt(Items3.Count - 1);
                    removed = true;
                }
                break;
        }

        if (removed)
        {
            NotifyChanged();
        }
    }

    public bool ConsumeItem(int slot)
    {
        var items = GetSlotItems(slot);
        if (items == null || items.Count == 0)
        {
            return false;
        }

        items.RemoveAt(0);
        NotifyChanged();
        return true;
    }

    public void Clear()
    {
        Items1.Clear();
        Items2.Clear();
        Items3.Clear();
        NotifyChanged();
    }

    public List<ItemData> GetSlotItems(int slot)
    {
        return slot switch
        {
            1 => Items1,
            2 => Items2,
            3 => Items3,
            _ => null
        };
    }

    private static bool TryAddToSlot(List<ItemData> slot, ItemData item)
    {
        if (slot.Count == 0)
        {
            slot.Add(item);
            return true;
        }

        if (slot[0].Id != item.Id)
        {
            return false;
        }

        if (!slot[0].Stackable || slot.Count >= slot[0].MaxStack)
        {
            return false;
        }

        slot.Add(item);
        return true;
    }

    private void NotifyChanged()
    {
        Changed?.Invoke();
    }
}
