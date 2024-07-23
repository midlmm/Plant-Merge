using System;
using System.Linq;
using UnityEngine;
public static class InventoryExtensions
{
    public static void Add(this Inventory inventory, InventoryItemConfig itemConfig, int count = 1)
    {
        var remainingCount = count;

        AddToSlotsWithSameItems(inventory, itemConfig, count, out remainingCount);

        if (remainingCount <= 0)
        {
            return;
        }

        count = remainingCount;

        AddToFirstAvalableSlot(inventory, itemConfig, count, out remainingCount);

        if (remainingCount > 0)
        {
            inventory.InvokeItemDroped(itemConfig, count);
        }
    }

    public static void Add(this Inventory inventory, Vector2Int slotCoordinates, InventoryItemConfig itemConfig, int count = 1)
    {
        var rowLenght = inventory.Size.x;
        var slotindex = slotCoordinates.x + rowLenght * slotCoordinates.y;
        var slot = inventory.Slots[slotindex];
        var newValue = slot.Count + count;

        if (slot.IsEmpty())
        {
            slot.ItemConfig = itemConfig;
        }

        if (newValue > slot.ItemConfig.Stack)
        {
            var remainigItems = newValue - slot.ItemConfig.Stack;
            var itemsToAddCount = slot.ItemConfig.Stack - slot.Count;
            slot.Count = slot.ItemConfig.Stack;

            inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, itemsToAddCount, slotCoordinates));

            inventory.Add(itemConfig, remainigItems);
        }
        else
        {
            slot.Count = newValue;

            inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, count, slotCoordinates));
        }
    }

    public static bool Remove(this Inventory inventory, InventoryItemConfig itemConfig, int count = 1, bool invokeDrop = true)
    {
        if (!inventory.CheckItems(itemConfig, count))
        {
            return false;
        }

        var countToRemove = count;
        var size = inventory.Size;
        var rowLenght = size.x;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var slotCoordinates = new Vector2Int(x, y);
                var slot = inventory.Slots[slotCoordinates.x + rowLenght * slotCoordinates.y];

                if (slot.ItemConfig != itemConfig)
                {
                    continue;
                }

                if (countToRemove > slot.Count)
                {
                    countToRemove -= slot.Count;
                    inventory.Remove(slotCoordinates, itemConfig, slot.Count, invokeDrop);
                }
                else
                {
                    inventory.Remove(slotCoordinates, itemConfig, slot.Count, invokeDrop);

                    return true;
                }
            }
        }

        return true;
    }

    public static bool Remove(this Inventory inventory, Vector2Int slotCoordinates, InventoryItemConfig itemConfig, int count = 1, bool invokeDrop = true)
    {
        var size = inventory.Size;
        var rowLength = size.x;
        var slot = inventory.Slots[slotCoordinates.x + rowLength * slotCoordinates.y];

        if (slot.IsEmpty() || slot.ItemConfig != itemConfig || slot.Count < count)
        {
            return false;
        }

        slot.Count -= count;

        if (slot.Count == 0)
        {
            slot.Clean();
        }

        inventory.InvokeItemRemoved(new InventoryEventArguments(itemConfig, count, slotCoordinates));

        if (invokeDrop)
        {
            inventory.InvokeItemDroped(itemConfig, count);
        }

        return true;
    }

    public static bool CheckItems(this Inventory inventory, InventoryItemConfig itemConfig, int count = 1)
    {
        var allSlotsWithItem = inventory.Slots.Where(s => s.ItemConfig == itemConfig);
        var sumExists = 0;

        foreach (var slot in allSlotsWithItem)
        {
            sumExists += slot.Count;
        }

        return sumExists >= count;
    }

    public static void AddToSlotsWithSameItems(Inventory inventory, InventoryItemConfig itemConfig, int count, out int remainingCount)
    {
        var size = inventory.Size;
        var rowLenght = size.x;
        remainingCount = count;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var coordinates = new Vector2Int(x, y);
                var slot = inventory.Slots[coordinates.x + rowLenght * coordinates.y];
                if (slot.IsEmpty())
                {
                    continue;
                }

                if (slot.Count >= slot.ItemConfig.Stack)
                {
                    continue;
                }

                if (slot.ItemConfig != itemConfig)
                {
                    continue;
                }

                var newValue = slot.Count + remainingCount;

                if (newValue > slot.ItemConfig.Stack)
                {
                    remainingCount = newValue - slot.ItemConfig.Stack;
                    slot.Count = slot.ItemConfig.Stack;

                    inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, slot.Count, coordinates)); 
                }
                else
                {
                    slot.Count = newValue;
                    remainingCount = 0;

                    inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, slot.Count, coordinates));
                    return;
                }
            }
        }
    }

    public static void AddToFirstAvalableSlot(Inventory inventory, InventoryItemConfig itemConfig, int count, out int remainingCount)
    {
        var size = inventory.Size;
        var rowLenght = size.x;
        remainingCount = count;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var coordinates = new Vector2Int(x, y);
                var slot = inventory.Slots[coordinates.x + rowLenght * coordinates.y];

                if (!slot.IsEmpty())
                {
                    continue;
                }

                slot.ItemConfig = itemConfig;
                var newValue = remainingCount;

                if (newValue > slot.ItemConfig.Stack)
                {
                    remainingCount = newValue - slot.ItemConfig.Stack;
                    var itemsToAddCount = slot.ItemConfig.Stack;
                    slot.Count = slot.ItemConfig.Stack;

                    inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, itemsToAddCount, coordinates));
                }
                else
                {
                    slot.Count = newValue;
                    var itemsToAddCount = remainingCount;
                    remainingCount = 0;

                    inventory.InvokeItemAdded(new InventoryEventArguments(itemConfig, itemsToAddCount, coordinates));
                    return;
                }
            }
        }
    }

    public static bool IsEmpty(this InventorySlot slot)
    {
        return slot.Count <= 0 || slot.ItemConfig == null;
    }
    public static void Clean(this InventorySlot slot)
    {
        slot.Count = 0;
        slot.ItemConfig = null;
    }

}
