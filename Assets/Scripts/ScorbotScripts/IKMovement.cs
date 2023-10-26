using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScorbotScripts
{
    public class IKMovement : MonoBehaviour
    {
        [SerializeField] public float momentum; // Ajusta la velocidad de movimiento según tus preferencias
        [SerializeField] public Transform ikTarget; // Asigna el IK Target desde el Inspector
        [SerializeField] public Transform center; // Asigna el objeto en el centro desde el Inspector
        private bool isMoving;
        [SerializeField] private bool movPositivo;
        [SerializeField] private float maxLength = 0.415f; //Radio limites exteriores
        [SerializeField] private float minLength = 0.128f; //Radio limites interiores
        [SerializeField] private Text speedText;
        [SerializeField] private int speed;

        private void Update()
        {
            //Comprobación limites exteriores
            ClampInnerLimit();
            ClampOuterLimit();
        }

        private void ClampInnerLimit()
        {
            //Comprobación limites interiores
            Vector3 vectorToInnerObject = ikTarget.position - center.position;
            if (vectorToInnerObject.magnitude < minLength)
            {
                vectorToInnerObject = vectorToInnerObject.normalized * minLength;
                ikTarget.position = center.position + vectorToInnerObject;
            }
        }

        private void ClampOuterLimit()
        {
            //Comprobación limites exteriores
            Vector3 vectorToObject = ikTarget.position - center.position;
            if (vectorToObject.magnitude > maxLength)
            {
                vectorToObject = Vector3.ClampMagnitude(vectorToObject, maxLength);
                ikTarget.position = center.position + vectorToObject;
            }
        }

        public void XMovement(bool sentido)
        {
            if (!isMoving)
            {
                int.TryParse(speedText.text, out speed);
                movPositivo = sentido;
                StartCoroutine(MoveObjectX());
            }
        }

        public void YMovement(bool sentido)
        {
            if (!isMoving)
            {
                int.TryParse(speedText.text, out speed);
                movPositivo = sentido;
                StartCoroutine(MoveObjectY());
            }
        }

        public void ZMovement(bool sentido)
        {
            if (!isMoving)
            {
                int.TryParse(speedText.text, out speed);
                movPositivo = sentido;
                StartCoroutine(MoveObjectZ());
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
                if (movPositivo)
                {
                    transform.Translate(movimientoX, 0, 0);
                }
                else
                {
                    transform.Translate(-movimientoX, 0, 0);
                }

                yield return null;
            }
        }

        private IEnumerator MoveObjectY()
        {
            isMoving = true;

            while (isMoving)
            {
                float movimientoY = momentum* speed * Time.deltaTime;
                if (movPositivo)
                {
                    transform.Translate(0, movimientoY, 0);
                }
                else
                {
                    transform.Translate(0, -movimientoY, 0);
                }

                yield return null;
            }
        }

        private IEnumerator MoveObjectZ()
        {
            isMoving = true;

            while (isMoving)
            {
                float movimientoZ = momentum* speed * Time.deltaTime;
                if (movPositivo)
                {
                    transform.Translate(0, 0, movimientoZ);
                }
                else
                {
                    transform.Translate(0, 0, -movimientoZ);
                }

                yield return null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 position = center.position;
            Gizmos.DrawWireSphere(position, maxLength);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(position, minLength);
        }
    }
}