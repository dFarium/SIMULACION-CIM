using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ToggleCinematic : MonoBehaviour
{
    // Lista de botones
    [SerializeField] private List<GameObject> botonesDirecto = new List<GameObject>();
    [SerializeField] private List<GameObject> botonesInverso = new List<GameObject>();

    // Método para abrir y cerrar la ventana
    public void SwitchCinematic()
    {
        Debug.Log(botonesDirecto[0].activeSelf);
        if (botonesDirecto[0].activeSelf)
        {
            foreach (GameObject botonD in botonesDirecto)
            {
                botonD.SetActive(false);
            }

            foreach (GameObject botonI in botonesInverso)
            {
                botonI.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject botonI in botonesInverso)
            {
                botonI.SetActive(false);
            }

            foreach (GameObject botonD in botonesDirecto)
            {
                botonD.SetActive(true);
            }
        }
    }
}