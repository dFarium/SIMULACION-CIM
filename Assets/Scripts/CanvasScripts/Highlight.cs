using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    [SerializeField] private string text;
    private Tooltip tooltip;
    // When highlighted with mouse.

    private void Start()
    {
        tooltip = FindAnyObjectByType<Tooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

    public void OnSelect(BaseEventData eventData)
    {
        tooltip.HideTooltip();
    }
}