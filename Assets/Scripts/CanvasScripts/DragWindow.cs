using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{

    [SerializeField] private  Canvas canvas;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
