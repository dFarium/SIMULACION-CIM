using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowCredits : MonoBehaviour
{
    [SerializeField] private CanvasGroup credits;
    
    public void ToggleCredits()
    {
        if (credits.alpha == 0)
        {
            credits.alpha = 1;
            credits.interactable = true;
            credits.blocksRaycasts = true;
        }
        else
        {
            credits.alpha = 0;
            credits.interactable = false;
            credits.blocksRaycasts = false;
        }
    }
}
