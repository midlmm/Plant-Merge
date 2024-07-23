using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private PlantItemPresent _plantItemPresent;

    [SerializeField] private Image _image;
    private Transform _dragParent;
    private bool _isDragging;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        _dragParent = transform.parent;
        transform.SetParent(transform.root);
        _image.raycastTarget = false;
        _isDragging = true;
        if (_dragParent.TryGetComponent<ITakingPlantItem>(out var takingPlantItem)) _plantItemPresent.OnEnterDrag(takingPlantItem);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragging) return;
        transform.SetParent(_dragParent);
        _image.raycastTarget = true;
        _isDragging = false;
        if (_dragParent.TryGetComponent<ITakingPlantItem>(out var takingPlantItem)) _plantItemPresent.OnEndDrag(takingPlantItem);
    }

    public void SetDragParent(Transform parent)
    {
        _dragParent = parent;
    }

    public void DisplayStage(Color color)
    {
        _image.color = color;
    }
}
