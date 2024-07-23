using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenSlot : MonoBehaviour
{
    [SerializeField] protected GardenSlotView _gardenSlotView;

    private PlantItemConfig _plantItemConfig;
    private int _currentSeconds;

    public void Accent(PlantItem plantItem)
    {
        _plantItemConfig = plantItem.PlantItemConfig;
        Destroy(plantItem.gameObject);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        _currentSeconds = _plantItemConfig.Seconds;
        while (_currentSeconds > 0)
        {
            _currentSeconds--;
            _gardenSlotView.DisplayTime(_currentSeconds);
            yield return new WaitForSeconds(1);
        }
    }
}
