using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotateLeaf : MonoBehaviour
{
    [SerializeField] private GameObject leaf;
    [SerializeField] public float momentum; // Ajusta la velocidad de movimiento según tus preferencias
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] public int speed;
    private bool isMoving;
    [SerializeField] private bool movPositivo;
    
    public void RotateLeafObject(bool sentido)
    {
        if (!isMoving)
        {
            int.TryParse(speedText.text, out speed);
            movPositivo = sentido;
            StartCoroutine(RotateLeafX());
        }
    }

    public void DetenerMovimiento()
    {
        StopAllCoroutines();
        isMoving = false;
    }

    private IEnumerator RotateLeafX()
    {
        isMoving = true;

        while (isMoving)
        {
            float movimientoX = momentum * speed * Time.deltaTime;
            if (movPositivo)
            {
                leaf.transform.Rotate(movimientoX, 0, 0);
            }
            else
            {
                leaf.transform.Rotate(-movimientoX, 0, 0);
            }
            yield return null;
        }
    }

}
