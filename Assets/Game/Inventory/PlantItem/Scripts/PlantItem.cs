using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItem : MonoBehaviour
{
    public int Stage { get; private set; }
    public PlantItemConfig PlantItemConfig { get; private set; }

    [SerializeField] private PlantItemView _plantItemView;
    [SerializeField] private PlantItemData _plantItemData;

    private void Start()
    {
        SetStage(0);
    }

    public void SetStage(int stage)
    {
        Stage = stage;
        PlantItemConfig = _plantItemData.PlantItemConfigs[Stage];
        _plantItemView.DisplayStage(PlantItemConfig.Color);
    }
}
