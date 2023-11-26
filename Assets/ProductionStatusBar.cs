using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using static ProductionManager;
using UnityEngine.UI;

public class ProductionStatusBar : MonoBehaviour
{
    private Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateFill(ProductionStatus status)
    {
        if (fillValues.TryGetValue(status, out var fillAmount))
        {
            image.DOFillAmount(fillAmount, 0.5f);
        }
        else
        {
            Debug.LogWarning("Estado desconocido: " + status);
        }
    }

    private readonly Dictionary<ProductionStatus, float> fillValues = new Dictionary<ProductionStatus, float>()
    {
        { ProductionStatus.Idle, 0f },
        { ProductionStatus.ToStation1, 0f },
        { ProductionStatus.GettingMaterial, 1/6f },
        { ProductionStatus.ToStation2, 2/6f },
        { ProductionStatus.Producing, 3/6f },
        { ProductionStatus.ToStation3, 4/6f },
        { ProductionStatus.Storing, 5/6f }, 
        { ProductionStatus.Disposing, 5/6f },
        { ProductionStatus.Finished, 6/6f }
        
    };
}