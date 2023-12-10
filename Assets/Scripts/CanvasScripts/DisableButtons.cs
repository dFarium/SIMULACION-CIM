using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisableButtons : MonoBehaviour
{
    [SerializeField] private List<Button> interactableButtons;
    
    public void SwitchEnableButton()
    {
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = !eventButtonTrigger.enabled;
            }
            buttons.interactable = !buttons.interactable;
        }
    }
}
