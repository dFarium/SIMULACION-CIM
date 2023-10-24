using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverCuboCineInv : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento; // Ajusta la velocidad de movimiento según tus preferencias
    [SerializeField] public Transform objectA; // Asigna el IK Target desde el Inspector
    [SerializeField] public Transform objectB; // Asigna el objeto en el centro desde el Inspector
    [SerializeField] public float distance; // Distancia entre el centro y el objeto guia de la cinematica
    private bool moviendo = false;
    [SerializeField] private bool movPositivo;
    private double disMax = 0.415; //Distancia maxima entre el cubo y el centro del Robot -> 0.412
    private double disMin = 0.128; //Distancia minima entre el cubo y el centro del Robot -> 0.128

    public void Start()
    {
        distance= distance = Vector3.Distance(objectA.position, objectB.position);
    }

    public void MovimientoX(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
            //distance = Vector3.Distance(objectA.position, objectB.position);
            StartCoroutine(MoverObjetoX());
        }
    }
    
    public void MovimientoY(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
            //distance = Vector3.Distance(objectA.position, objectB.position);
            StartCoroutine(MoverObjetoY());
        }
    }
    
    public void MovimientoZ(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
            //distance = Vector3.Distance(objectA.position, objectB.position);
            StartCoroutine(MoverObjetoZ());
        }
    }
    public void DetenerMovimiento()
    {
        StopAllCoroutines();
        moviendo = false;
    }
    
    private IEnumerator MoverObjetoX()
    {
        moviendo = true;

        while (moviendo)
        {
            float movimientoX = velocidadMovimiento * Time.deltaTime;
            if (movPositivo)
            {
                distance = Vector3.Distance(objectA.position + new Vector3(movimientoX, 0, 0), objectB.position);
                if (distance < disMax && distance > disMin)
                { 
                    transform.Translate(movimientoX, 0, 0);
                }
            }
            else
            {
                distance = Vector3.Distance(objectA.position + new Vector3(-movimientoX, 0, 0), objectB.position);
                if (distance<disMax && distance>disMin)
                {
                    transform.Translate(-movimientoX, 0, 0);
                }
            }
            yield return null;
        }
    }
    
    private IEnumerator MoverObjetoY()
    {
        moviendo = true;

        while (moviendo)
        {
            float movimientoY = velocidadMovimiento * Time.deltaTime;
            if (movPositivo)
            {
                distance = Vector3.Distance(objectA.position + new Vector3(0, movimientoY, 0), objectB.position);
                if (distance<disMax && distance>disMin)
                {
                    transform.Translate(0, movimientoY, 0);                    
                }
            }
            else
            {
                distance = Vector3.Distance(objectA.position + new Vector3(0,-movimientoY, 0), objectB.position);
                if (distance<disMax && distance>disMin)
                {
                    transform.Translate(0,-movimientoY, 0);
                }
            }
            yield return null;
        }
    }
    
    private IEnumerator MoverObjetoZ()
    {
        moviendo = true;

        while (moviendo)
        {
            float movimientoZ = velocidadMovimiento * Time.deltaTime;
            if (movPositivo)
            {
                distance = Vector3.Distance(objectA.position + new Vector3(0, 0, movimientoZ), objectB.position);
                if ( distance<disMax && distance>disMin)
                {
                    transform.Translate(0, 0, movimientoZ);                    
                }
            }
            else
            {
                distance = Vector3.Distance(objectA.position + new Vector3(0, 0, -movimientoZ), objectB.position);
                if (distance<disMax && distance>disMin)
                {
                    transform.Translate(0, 0, -movimientoZ);
                }
            }
            yield return null;
        }
    }
}