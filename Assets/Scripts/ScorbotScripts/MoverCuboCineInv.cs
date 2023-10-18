using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverCuboCineInv : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento; // Ajusta la velocidad de movimiento según tus preferencias
    private bool moviendo = false;
    private bool movPositivo;

    public void MovimientoX(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
            StartCoroutine(MoverObjetoX());
        }
    }
    
    public void MovimientoY(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
            StartCoroutine(MoverObjetoY());
        }
    }
    
    public void MovimientoZ(bool sentido)
    {
        if (!moviendo)
        {
            movPositivo = sentido;
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
                transform.Translate(movimientoX, 0, 0);   
            }
            else
            {
                transform.Translate((-1)*movimientoX, 0, 0);
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
                transform.Translate(0, movimientoY, 0);   
            }
            else
            {
                transform.Translate(0,(-1)*movimientoY, 0);
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
                transform.Translate(0, 0, movimientoZ);   
            }
            else
            {
                transform.Translate(0, 0, (-1)*movimientoZ);
            }
            yield return null;
        }
    }
}