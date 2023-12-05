using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelColor : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;
    private List<Color> originalColors;
    private float changeColorFactor = 0.2f;
    private bool isEventTriggerEnabled = true;

    private void Start()
    {
        originalColors = new List<Color>(panels.Count);
        foreach (var panel in panels)
        {
            originalColors.Add(panel.GetComponent<Image>().color);
        }
    }

    public void PointerDownPanel()
    {
        if (!isEventTriggerEnabled) return;
        
        isEventTriggerEnabled = false;
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Image>().color = ChangeColor(panel.GetComponent<Image>().color);
        }
        isEventTriggerEnabled = true;
    }

    public void PointerUpPanel()
    {
        if (!isEventTriggerEnabled) return;

        isEventTriggerEnabled = false;
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].GetComponent<Image>().color = originalColors[i];
        }

        isEventTriggerEnabled = true;
    }

    private Color ChangeColor(Color originalColor)
    {
        // Ajusta cada componente RGB del color original multiplicándolo por el factor de oscurecimiento
        return new Color(
            originalColor.r * (1 - changeColorFactor),
            originalColor.g * (1 - changeColorFactor),
            originalColor.b * (1 - changeColorFactor),
            originalColor.a
        );
    }
}