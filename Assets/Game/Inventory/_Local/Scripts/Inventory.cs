using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory 
{
    public event Action<InventoryEventArguments> ItemAdded;
    public event Action<InventoryEventArguments> ItemRemoved;
    public event Action<InventoryItemConfig, int> ItemDroped;

    public List<InventorySlot> Slots;
    public Vector2Int Size;

    public Inventory(InventoryConfig inventoryConfig)
    {
        Size = inventoryConfig.InventorySize;

        var size = Size;
        Slots = new List<InventorySlot>(size.x * size.y);
        for (int i = 0; i < Size.x * Size.y; i++)
        {
            Slots.Add(new InventorySlot());
        }
    }
    public void InvokeItemAdded(InventoryEventArguments inventoryEventArguments)
    {
        ItemAdded?.Invoke(inventoryEventArguments);
    }

    public void InvokeItemRemoved(InventoryEventArguments inventoryEventArguments)
    {
        ItemRemoved?.Invoke(inventoryEventArguments);
    }

    public void InvokeItemDroped(InventoryItemConfig itemConfig, int count)
    {
        ItemDroped?.Invoke(itemConfig, count);
    }

    public void PrintInventory()
    {
        var line = "";
        var size = Size;
        var rowLenght = size.x;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var coords = new Vector2Int(x, y);
                var slot = Slots[coords.x + rowLenght * y];
                
                if(slot.ItemConfig == null)
                {
                    //Debug.Log($"Slot ({x}, {y}): Item = null, Count {slot.Count}");
                }    
                else
                {
                    //Debug.Log($"Slot ({x}, {y}): Item = {slot.ItemConfig.Name}, Count {slot.Count}");
                }
            }
            line = "\n";
        }
        Debug.Log(line);
    }
}
