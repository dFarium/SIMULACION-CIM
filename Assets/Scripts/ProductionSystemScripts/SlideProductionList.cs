using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlideProductionList : MonoBehaviour
{
    [SerializeField] private RectTransform showProductionList;
    [SerializeField] private RectTransform hideProductionList;
    [SerializeField] private RectTransform image;
    [SerializeField] private bool isProductionListShown;
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
        image.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.InOutCubic);
        transform.DOMove(hideProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isProductionListShown = false;
    }
    
    private void ShowProductionList()
    {
        image.DORotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.InOutCubic);
        transform.DOMove(showProductionList.position, 1f).SetEase(Ease.InOutCubic);
        isProductionListShown = true;
    }
}
