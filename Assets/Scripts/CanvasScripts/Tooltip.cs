using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float delay;
    [SerializeField]private CanvasGroup canvasGroup;
    private Transform backGroundParent;
    private TMP_Text tooltipText;
    private Vector3 mousePosition;
    private bool isHighlighted, isDelaying;
    private float timer;
    
    private void Start()
    {
        backGroundParent = transform.parent;
        tooltipText = GetComponent<TMP_Text>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        isHighlighted = false;
        canvasGroup.alpha = 0;
    }

    private void Update()
    {
        if (isHighlighted)
        {   
            mousePosition = Input.mousePosition;
            backGroundParent.position = mousePosition + (Vector3.up * height) ;
        }
        
        if (isDelaying)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay)
        {
            isDelaying = false;
            isHighlighted = true;
            canvasGroup.alpha = 1;
        }
    }

    public void ShowTooltip(string text)
    {
        timer = 0;
        isDelaying = true;
        tooltipText.text = text;
        isHighlighted = true;
    }

    public void HideTooltip()
    {
        timer = 0;
        isHighlighted = false;
        isDelaying = false;
        canvasGroup.alpha = 0;
    }

    private IEnumerator DelayTooltip(string text)
    {
        yield return new WaitForSeconds(1);
        tooltipText.text = text;
        isHighlighted = true;
        canvasGroup.alpha = 1;
    }
}