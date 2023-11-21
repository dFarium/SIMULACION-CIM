using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleBotonera : MonoBehaviour
{ 
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private TextMeshProUGUI controlMainText;
    [SerializeField] private Button controlButton;
    private Color defaultColor;
    
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
        controlMainText.gameObject.SetActive(false);
        //Cambia el color del boton de control
        controlButton.image.color = Color.white;
        foreach (Button buttons  in interactableButtons)
        {
            buttons.interactable=false;
        }
    }
    
    public void encenderBotonera()
    {
        controlMainText.gameObject.SetActive(true);
        controlButton.image.color = defaultColor;
        foreach (Button buttons  in interactableButtons)
        {
            buttons.interactable=true;
        }
    }

    public void Start()
    {
        defaultColor = controlButton.image.color;
        apagarBotonera();
    }
}
