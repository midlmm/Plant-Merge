using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MergeSlotPresent : MonoBehaviour
{
    [SerializeField] private MergeSlot _mergeSlot;

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
        if (_mergeSlot.PlantItem == null)
        {
            return true;
        }
        else if (_mergeSlot.PlantItem.Stage == plantItem.Stage)
        {
            _mergeSlot.Accent(plantItem);
            return true;
        }
        else
        {
            return false;
        }
    }

}
