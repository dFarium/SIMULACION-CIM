using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string text;
    [SerializeField] private Tooltip tooltip;
    // When highlighted with mouse.
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