using UnityEngine;

public class RodearCollider : MonoBehaviour
{
    // La zona que queremos rodear
    public GameObject zona;

    // La velocidad de movimiento del gameobject
    public float velocidad = 5f;

    // La velocidad de rotación del gameobject
    public float velocidadAngular = 10f;

    // La distancia mínima a la que queremos estar de la zona
    public float distanciaMinima = 0.1f;

    void Update()
    {
        // Calculamos la dirección hacia la zona
        Vector3 direccion = zona.transform.position - transform.position;

        // Calculamos la distancia a la zona
        float distancia = direccion.magnitude;

        // Si la distancia es menor que el mínimo, movemos el gameobject en una dirección perpendicular a la zona
        if (distancia < distanciaMinima)
        {
            // Obtenemos un vector perpendicular a la dirección usando el producto cruzado con el vector arriba
            Vector3 perpendicular = Vector3.Cross(direccion, Vector3.up);

            // Normalizamos el vector perpendicular para que tenga magnitud 1
            perpendicular = perpendicular.normalized;

            // Movemos el gameobject hacia el vector perpendicular usando la función MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, transform.position + perpendicular, velocidad * Time.deltaTime);
        }
        else
        {
            // Si la distancia es mayor que el mínimo, movemos el gameobject hacia la zona usando la función MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, zona.transform.position, velocidad * Time.deltaTime);
        }

        // Rotamos el gameobject hacia la zona usando la función RotateTowards
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, velocidadAngular * Time.deltaTime);
    }
}