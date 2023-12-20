using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    private Quaternion defaultRotation;
    
    private void Rotation()
    {
        transform.rotation = defaultRotation;
        Vector3 rotation = new Vector3(0, 360, 0);
        transform.DORotate(rotation, 5.0f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void Awake()
    {
        defaultRotation = transform.rotation;
        Rotation();
    }

    private void OnEnable()
    {
        transform.rotation = defaultRotation;
        Rotation();
    }
    
    private void OnDisable()
    {
        transform.DOKill();
    }
}