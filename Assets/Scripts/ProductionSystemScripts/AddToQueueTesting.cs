using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AddToQueueTesting : MonoBehaviour
{
    [Header("ESSENTIAL")] [SerializeField]
    private List<ProductionMaterial> productionMaterials = new List<ProductionMaterial>();

    
    [SerializeField] private ProductionManager productionManager;


    private void Start()
    {
        Random random = new Random();
        foreach (ProductionMaterial productionMaterial in productionMaterials)
        {
            productionManager.AddToQueue(productionMaterial, random.Next(1,101), false);
        }
    }
}