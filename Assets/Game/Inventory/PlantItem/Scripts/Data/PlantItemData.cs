using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Plant Item Data")]
public class PlantItemData : ScriptableObject
{
    public PlantItemConfig[] PlantItemConfigs => _plantItemConfigs;

    [SerializeField] private PlantItemConfig[] _plantItemConfigs;
}
