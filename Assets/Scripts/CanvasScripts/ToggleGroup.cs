using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ToggleGroup : MonoBehaviour
{
    // Lista de botones
    [SerializeField] private List<GameObject> aGroupButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> bGroupButtons = new List<GameObject>();

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
            groupText.text = "GROUP A";
        }
    }
}
