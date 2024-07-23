using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GardenSlotView : MonoBehaviour, IDropHandler
{
    [SerializeField] private protected GardenSlotPresent _gardenSlotPresent;

    [SerializeField] private TMP_Text _textTime;

    public void OnDrop(PointerEventData eventData)
    {
        _gardenSlotPresent.OnDropped(eventData);
    }

    public void DisplayTime(int seconds)
    {
        _textTime.text = seconds + "c";
    }
}
