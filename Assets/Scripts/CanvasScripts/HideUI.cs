using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    // Lista de botones
    [SerializeField] private List<GameObject> groupButtons = new List<GameObject>();
    [SerializeField] private GameObject helpPanel;
    
    // Método para desactivar botones
    public void HideAllButtons()
    {
        foreach (GameObject buttons in groupButtons)
        {
            buttons.SetActive(false);
        }
        
        helpPanel.SetActive(true);
    
    }
    
    // Método para mostrar botones
    public void ShowAllButtons()
    {
        helpPanel.SetActive(false);
        
        foreach (GameObject buttons in groupButtons)
        {
            buttons.SetActive(true);
        }
    }
}
