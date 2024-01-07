using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NextCamera : MonoBehaviour
{
    // botones
    [SerializeField] private GameObject nextCamera;
    
    // Método para cambiar a la siguiente cámara
    public void SwitchNextCamera()
    {
        gameObject.SetActive(false);
        nextCamera.SetActive(true);
    }
}
