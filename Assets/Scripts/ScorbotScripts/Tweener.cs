using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    [SerializeField]private Transform destino;
    

    private void Start()
    {
        transform.DOMove(destino.position, 5, false).SetEase(Ease.InOutCubic).SetLoops(-1,LoopType.Yoyo);
    }
}
