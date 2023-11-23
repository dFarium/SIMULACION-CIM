using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProductionQueueItem
{
    public ProductionMaterial productionMaterial;
    public float priority;
    public bool requiresManualReview;
    public int queueNumber;
    public float manufacturingTime;
    
    public ProductionQueueItem(ProductionMaterial productionMaterial, float priority, bool requiresManualReview, int queueNumber)
    {
        this.productionMaterial = productionMaterial;
        this.priority = priority;
        this.requiresManualReview = requiresManualReview;
        this.queueNumber = queueNumber;
        this.manufacturingTime = productionMaterial.manufacturingTime;
    }
}