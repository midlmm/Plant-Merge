using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    //[SerializeField] private GameObject _prefabSlot;
    //[SerializeField] private Transform _content;

    //private Inventory _inventory;
    //private Dictionary<Vector2Int, SlotView> _slots = new Dictionary<Vector2Int, SlotView>();

    //public void Initialized(Inventory inventory)
    //{
    //    _inventory = inventory;
    //    _inventory.ItemAdded += ItemAdded;
    //    SpawnAllSlots();
    //}

    //public void SpawnAllSlots()
    //{
    //    for (int x = 0; x < _inventory.Size.x; x++)
    //    {
    //        for (int y = 0; y < _inventory.Size.y; y++)
    //        {
    //            var slot = Instantiate(_prefabSlot, _content);
    //            var slotView = slot.GetComponent<SlotView>();
    //            slotView.Initialized();
    //            _slots.Add(new Vector2Int(x, y), slotView);
    //        }
    //    }
    //}

    //private void ItemAdded(InventoryEventArguments inventoryEventArguments)
    //{
    //    var slot = _slots[inventoryEventArguments.InventorySlotCoordinates];
    //    slot.UpdateSlot(inventoryEventArguments.ItemOptions, inventoryEventArguments.Count);
    //}
}
