using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleBotonera : MonoBehaviour
{ 
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private TextMeshProUGUI controlMainText;
    [SerializeField] private List<TextMeshProUGUI> subControlText;
    [SerializeField] private Button controlButton;
    
    private Color defaultColor;
    private string defaultControlText = "awaiting  action";
    
    public void switchBotonera()
    {
        if (controlMainText.gameObject.activeSelf)
        {
            apagarBotonera();
        }
        else
        {
            encenderBotonera();
        }
    }
    
    public void apagarBotonera()
    {
        StopAllCoroutines();
        //Manda un mensaje que indica que el control esta desactivado y lo desactiva
        controlMainText.text = "Control disabled";
        StartCoroutine(TextDelay(1, false));
        
        //Cambia el color del boton de control
        controlButton.image.color = Color.white;
        
        //Desactiva los botones de la botonera
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = false;
            }
            buttons.interactable=false;
        }

    }
    
    public void encenderBotonera()
    {
        controlMainText.text = "Control enabled";
        controlMainText.gameObject.SetActive(true);
        foreach (TextMeshProUGUI text in subControlText)
        {
            text.gameObject.SetActive(true);
        }
        StartCoroutine(TextDelay(1, true));
        
        controlButton.image.color = defaultColor;
        
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = true;
            }
            buttons.interactable=true;
        }
    }

    public void Start()
    {
        //Recuerda el color original del boton
        defaultColor = controlButton.image.color;
        
        //Desactiva los textos de la botonera
        controlMainText.gameObject.SetActive(false);
        foreach (TextMeshProUGUI text in subControlText)
        {
            text.gameObject.SetActive(false);
        }
        
        //Cambia el color del boton de control
        controlButton.image.color = Color.white;
        
        //Desactiva los botones de la botonera
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = false;
            }
            buttons.interactable=false;
        }
    }
    
    private IEnumerator TextDelay(int numero, bool onOff)
    {
        yield return new WaitForSeconds(numero);
        if (onOff)
        {
            controlMainText.text = defaultControlText;
        }
        else
        {
            controlMainText.gameObject.SetActive(false);
            foreach (TextMeshProUGUI text in subControlText)
            {
                text.gameObject.SetActive(false);
            }
        }
    }
}
