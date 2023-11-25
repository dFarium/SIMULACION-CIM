using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleCinematic : MonoBehaviour
{
    // Lista de botones
    [SerializeField] private List<GameObject> botonesDirecto = new List<GameObject>();
    [SerializeField] private List<GameObject> botonesInverso = new List<GameObject>();

    //String de abajo a la derecha en la botonera
    [SerializeField] private TextMeshProUGUI cinematicText;
    
    // Método para cambiar la cinematica
    public void SwitchCinematic()
    {
        if (cinematicText.text == "JOINTS")
        {
            //Cinematica inversa
            foreach (GameObject botonD in botonesDirecto)
            {
                botonD.SetActive(false);
            }
            foreach (GameObject botonI in botonesInverso)
            {
                botonI.SetActive(true);
            }
            cinematicText.text = "XYZ";
            
        }
        else
        {
            //Cinematica directa
            foreach (GameObject botonI in botonesInverso)
            {
                botonI.SetActive(false);
            }
            foreach (GameObject botonD in botonesDirecto)
            {
                botonD.SetActive(true);
            }
            cinematicText.text = "JOINTS";
        }
    }
}