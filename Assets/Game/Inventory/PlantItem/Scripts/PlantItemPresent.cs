using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItemPresent : MonoBehaviour
{
    [SerializeField] private PlantItem _plantItem;

    public void OnEnterDrag(ITakingPlantItem takingPlantItem)
    {
        takingPlantItem.SetPlantItem(null);
    }

    public void OnEndDrag(ITakingPlantItem takingPlantItem)
    {
        takingPlantItem.SetPlantItem(_plantItem);
    }
}
