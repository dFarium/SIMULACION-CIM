using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private float altura;
    private CanvasGroup canvasGroup;
    private TMP_Text tooltipText;
    private Vector3 mousePosition;
    private bool isHighlighted, isDelaying;
    [SerializeField]private float timer;
    
    private void Start()
    {
        tooltipText = GetComponent<TMP_Text>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
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
            transform.position = mousePosition + Vector3.up * altura;
        }
        
        if (isDelaying)
        {
            timer += Time.deltaTime;
        }

        if (timer > 1)
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