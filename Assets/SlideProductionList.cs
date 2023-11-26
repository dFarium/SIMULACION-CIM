using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlideProductionList : MonoBehaviour
{
    [SerializeField] private RectTransform showProductionList;
    [SerializeField] private RectTransform hideProductionList;
    private bool isProductionListShown = false;
    // Start is called before the first frame update
    
    public void ToggleProductionList()
    {
        if (isProductionListShown)
        {
            HideProductionList();
        }
        else
        {
            ShowProductionList();
        }
    }
    
    private void HideProductionList()
    {
        transform.DOMove(hideProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isProductionListShown = false;
    }
    
    private void ShowProductionList()
    {
        transform.DOMove(showProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isProductionListShown = true;
    }
}
