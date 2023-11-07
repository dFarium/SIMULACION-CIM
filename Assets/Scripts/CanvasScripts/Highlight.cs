using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(0, 10)] [SerializeField] private string text;
    private Tooltip tooltip;
    private Button button;
    // When highlighted with mouse.

    private void Start()
    {
        button = GetComponent<Button>();
        tooltip = FindAnyObjectByType<Tooltip>();
        
        button.onClick.AddListener(OnClickButton);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
    
    private void OnClickButton()
    {
        tooltip.HideTooltip();
    }
}