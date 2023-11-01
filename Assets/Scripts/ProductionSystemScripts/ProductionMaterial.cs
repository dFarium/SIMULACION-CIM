using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductionMaterial", menuName = "Production Material")]
public class ProductionMaterial : ScriptableObject
{
    public GameObject baseMaterial;
    public GameObject finalProduct;
    public float manufacturingTime;
}
