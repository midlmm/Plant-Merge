using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GardenSlotPresent : MonoBehaviour
{
    [SerializeField] private GardenSlot _gardenSlot;

    public void OnDropped(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        PlantItemView mergeItemView = dropped.GetComponent<PlantItemView>();
        PlantItem mergeItem = dropped.GetComponent<PlantItem>();
        if (CheckingDrop(mergeItem))
        {
            mergeItemView.SetDragParent(transform);
        }
    }

    private bool CheckingDrop(PlantItem plantItem)
    {
        _gardenSlot.Accent(plantItem);
        return true;
    }
}
