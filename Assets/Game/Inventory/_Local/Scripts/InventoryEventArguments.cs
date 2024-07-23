using UnityEngine;

public struct InventoryEventArguments 
{
    public InventoryItemConfig ItemConfig { get; }
    public int Count { get; }
    public Vector2Int InventorySlotCoordinates { get; }

    public InventoryEventArguments(InventoryItemConfig itemConfig, int count, Vector2Int inventorySlotCoordinates)
    {
        ItemConfig = itemConfig;
        Count = count;
        InventorySlotCoordinates = inventorySlotCoordinates;
    }
}
