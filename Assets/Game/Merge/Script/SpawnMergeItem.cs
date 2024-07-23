using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMergeItem : MonoBehaviour
{
    [SerializeField] private MergeSlot[] _mergeSlots;
    [SerializeField] private GameObject _prefabMergeItem;

    public void Spawn()
    {
        if (!CheckingNullMergeSlot()) return;
        MergeSlot mergeSlot = _mergeSlots[GetRandomMergeSlot()];
        PlantItem mergeItem = Instantiate(_prefabMergeItem, mergeSlot.transform).GetComponent<PlantItem>();
        mergeSlot.SetPlantItem(mergeItem);
    }

    private int GetRandomMergeSlot()
    {
        int id = Random.Range(0, _mergeSlots.Length);
        while (_mergeSlots[id].PlantItem != null)
        {
            id = Random.Range(0, _mergeSlots.Length);
        }
        return id;
    }

    private bool CheckingNullMergeSlot()
    {
        bool isActive = false;
        foreach (var item in _mergeSlots)
        {
            if (item.PlantItem == null) isActive = true;
        }
        return isActive;
    }
}
