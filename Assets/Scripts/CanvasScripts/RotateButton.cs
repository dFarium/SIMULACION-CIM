using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    private bool isAuto;
    [SerializeField] private float durationAnimation;
    
    void Start()
    {
        isAuto = false;
    }
    
    public void SwitchRotate()
    {
        if (isAuto)
        {
            transform.DORotate(new Vector3(0,0,0),durationAnimation).SetEase(Ease.Linear);
            isAuto = false;
        }
        else
        {
            transform.DORotate(new Vector3(0,0,-90),durationAnimation).SetEase(Ease.Linear);
            isAuto = true;
        }
    } 
}
