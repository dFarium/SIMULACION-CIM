using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class ProductionQueueItem
{
    public ProductionMaterial productionMaterial;
    public float priority;
    [FormerlySerializedAs("requiresManualReview")] public bool isBeingStored;
    public int queueNumber;
    public float manufacturingTime;
    
    public ProductionQueueItem(ProductionMaterial productionMaterial, float priority, bool isBeingStored, int queueNumber)
    {
        this.productionMaterial = productionMaterial;
        this.priority = priority;
        this.isBeingStored = isBeingStored;
        this.queueNumber = queueNumber;
        this.manufacturingTime = productionMaterial.manufacturingTime;
    }
}