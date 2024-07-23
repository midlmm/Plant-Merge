using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSlot : MonoBehaviour, ITakingPlantItem
{
    public PlantItem PlantItem { get; private set; }

    public void SetPlantItem(PlantItem plantItem)
    {
        PlantItem = plantItem;
    }

    public void Accent(PlantItem plantItem)
    {
        Destroy(PlantItem.gameObject);
        SetPlantItem(plantItem);
        PlantItem.SetStage(PlantItem.Stage + 1);
    }
}
