using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject image;
    [SerializeField] private Transform showPanel;
    [SerializeField] private Transform hidePanel;
    private bool isShowing = true;
    
    public void SwitchPanel()
    {
        if (isShowing)
        {
            panel.transform.DOMove(hidePanel.position, 1f).SetEase(Ease.InOutCubic);
            image.transform.DORotate(new Vector3(0,0,0), 1f).SetEase(Ease.InOutCubic);
            isShowing = false;
        }
        else
        {
            panel.transform.DOMove(showPanel.position, 1f).SetEase(Ease.InOutCubic);
            image.transform.DORotate(new Vector3(0,180,0), 1f).SetEase(Ease.InOutCubic);
            isShowing = true;
        }
    }
    
}
