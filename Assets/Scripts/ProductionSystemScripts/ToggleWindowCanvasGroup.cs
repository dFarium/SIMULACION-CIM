using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWindowCanvasGroup : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private CanvasGroup addForm;
    [SerializeField] private CanvasGroup removeForm;
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

    public void SwitchWindowForm()
    {
        if (addForm.alpha == 0)
        {
            addForm.alpha = 1;
            addForm.interactable = true;
            addForm.blocksRaycasts = true;
            
            removeForm.alpha = 0;
            removeForm.interactable = false;
            removeForm.blocksRaycasts = false;
        }
        else
        {
            addForm.alpha = 0;
            addForm.interactable = false;
            addForm.blocksRaycasts = false;
            
            removeForm.alpha = 1;
            removeForm.interactable = true;
            removeForm.blocksRaycasts = true;
        }
    }
}
