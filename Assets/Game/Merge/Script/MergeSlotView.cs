using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MergeSlotView : MonoBehaviour, IDropHandler
{
    [SerializeField] private protected MergeSlotPresent _mergeSlotPresent;

    public void OnDrop(PointerEventData eventData)
    {
        _mergeSlotPresent.OnDropped(eventData);
    }

}
