using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RailMovement : MonoBehaviour
{
    [SerializeField] public float momentum; // Ajusta la velocidad de movimiento según tus preferencias
    [SerializeField] private Text speedText;
    [SerializeField] public int speed;
    private bool isMoving;
    [SerializeField] private bool movPositivo;
    [SerializeField] private GameObject limitR; //Gameobject que indica el limite derecho del riel
    [SerializeField] private GameObject limitL; //Gameobject que indica el limite izquierdo del riel

    public void XMovement(bool sentido)
    {
        if (!isMoving)
        {
            int.TryParse(speedText.text, out speed);
            movPositivo = sentido;
            StartCoroutine(MoveObjectX());
        }
    }

    public void DetenerMovimiento()
    {
        StopAllCoroutines();
        isMoving = false;
    }

    private IEnumerator MoveObjectX()
    {
        isMoving = true;

        while (isMoving)
        {
            float movimientoX = momentum * speed * Time.deltaTime;
            if (movPositivo && transform.position.x < limitL.transform.position.x)
            {
                transform.Translate(movimientoX, 0, 0);
            }
            else
            {
                if (!movPositivo && transform.position.x > limitR.transform.position.x)
                {
                    transform.Translate(-movimientoX, 0, 0);
                }
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Vector3 position = center.position;
        Gizmos.DrawLine(limitL.transform.position, limitR.transform.position);
    }
}