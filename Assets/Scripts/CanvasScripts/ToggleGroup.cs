using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    // Lista de botones
    [SerializeField] private List<GameObject> aGroupButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> bGroupButtons = new List<GameObject>();
    [SerializeField] private List<Button> interactableButtons = new List<Button>();

    //String de abajo a la izq en la botonera
    [SerializeField] private TextMeshProUGUI groupText;
    
    // Método para cambiar el grupo
    public void SwitchGroup()
    {
        if (groupText.text == "GROUP A")
        {
            //Group B
            foreach (GameObject A_Button in aGroupButtons)
            {
                A_Button.SetActive(false);
            }
            foreach (GameObject B_Button in bGroupButtons)
            {
                B_Button.SetActive(true);
            }
            //Se desactivan las funciones de los botones del grupo A, pero se conserva su imagen
            foreach (Button buttons  in interactableButtons)
            {
                EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
                if (eventButtonTrigger != null)
                {
                    eventButtonTrigger.enabled = false;
                }
            }
            groupText.text = "GROUP B";
            
        }
        else
        {
            //Group A
            foreach (GameObject B_Button in bGroupButtons)
            {
                B_Button.SetActive(false);
            }
            foreach (GameObject A_Button in aGroupButtons)
            {
                A_Button.SetActive(true);
            }
            foreach (Button buttons  in interactableButtons)
            {
                EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
                if (eventButtonTrigger != null)
                {
                    eventButtonTrigger.enabled = true;
                }
            }
            groupText.text = "GROUP A";
        }
    }
}
