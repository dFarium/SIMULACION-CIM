using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para almacenar los elementos de la cola de producción
[CreateAssetMenu(fileName = "ProductionMaterial", menuName = "Production Material")]
public class ProductionMaterial : ScriptableObject
{
    public string materialName;
    public GameObject baseMaterial;
    public UnityEngine.Material finalProductMaterial;
    public float manufacturingTime;
}
