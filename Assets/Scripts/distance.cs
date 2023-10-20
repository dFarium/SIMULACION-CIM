using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class distance : MonoBehaviour
{
    
    [SerializeField] public Transform objectA; // Asigna el objeto A desde el Inspector
    [SerializeField] public Transform objectB; // Asigna el objeto B desde el Inspector

    // Start is called before the first frame update
    void dist()
    {
        float distance = Vector3.Distance(objectA.position, objectB.position);
        Debug.Log("Distancia entre A y B: " + distance);
    }
}
