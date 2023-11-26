using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWindowCanvasGroup : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    private CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleWindow()
    {
        if (canvasGroup.alpha == 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            backgroundPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
