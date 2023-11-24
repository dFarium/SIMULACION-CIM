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
        //Se agregan los materiales a la cola de producción
        Random random = new Random();
        foreach (ProductionMaterial productionMaterial in productionMaterials)
        {
            productionManager.AddToQueue(productionMaterial, random.Next(1, 100), false);
        }
    }
}