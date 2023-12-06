using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ToggleWindow : MonoBehaviour
{
    // Interfaz a Activar/Desactivar
    [SerializeField] private GameObject interfaz;

    [SerializeField] private GameObject backgroundPanel;

    // Método para abrir y cerrar la interfaz
    public void SwitchWindow()
    {
        
        if (interfaz.activeSelf)
        {
                interfaz.SetActive(false);
        }
        else
        {
            backgroundPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            interfaz.SetActive(true);
        }
    }

    public void DisableWindow()
    {
        interfaz.SetActive(false);
    }
}