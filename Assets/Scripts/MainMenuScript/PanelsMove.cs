using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelsMove : MonoBehaviour
{
    [SerializeField] private RectTransform showProductionList;
    [SerializeField] private RectTransform hideProductionList;
    private bool isPanelShow;
    // Start is called before the first frame update

    public void Start()
    {
        isPanelShow = false;
    }

    public void ToggleProductionList()
    {
        if (isPanelShow)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
    }
    
    private void HidePanel()
    {
        transform.DOMove(hideProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isPanelShow = false;
    }
    
    private void ShowPanel()
    {
        transform.DOMove(showProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isPanelShow = true;
    }
}