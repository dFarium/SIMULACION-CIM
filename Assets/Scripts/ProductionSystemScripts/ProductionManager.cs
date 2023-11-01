using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    [Header("Production Status")] [SerializeField]
    private float productionTimer;

    [SerializeField] private GameObject baseMaterial, finalProduct;
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private float cooldownTimer = 0;
    [SerializeField] private Transform station1SpawnPoint, station2SpawnPoint;
    [SerializeField] private List<ProductionQueueItem> productionQueue = new List<ProductionQueueItem>();
    private GameObject currentFinalProduct; // Variable para almacenar el producto final actual
    private bool isBaseMaterialSpawned;

    [System.Serializable]
    public class ProductionQueueItem
    {
        public ProductionMaterial material;
        public float priority;
        public bool requiresManualReview;
        
        public ProductionQueueItem(ProductionMaterial material, float priority, bool requiresManualReview)
        {
            this.material = material;
            this.priority = priority;
            this.requiresManualReview = requiresManualReview;
        }
    }

    public void AddToQueue(ProductionMaterial material, float priority, bool requiresManualReview)
    {
        ProductionQueueItem newItem = new ProductionQueueItem(material, priority, requiresManualReview);
        productionQueue.Add(newItem);
        SortQueueByPriority(); // Ordena la cola después de agregar un elemento.
    }

    public void RemoveFromQueue(ProductionQueueItem item)
    {
        productionQueue.Remove(item);
    }

    //Ordena la cola de producción por prioridad, de mayor a menor
    public void SortQueueByPriority()
    {
        productionQueue.Sort((a, b) => b.priority.CompareTo(a.priority));
    }

    public void SpawnBaseMaterial(ProductionMaterial material, Transform spawnPoint)
    {
        baseMaterial = Instantiate(material.baseMaterial, spawnPoint);
    }

    public void SpawnFinalProduct(ProductionMaterial material, Transform spawnPoint)
    {
        finalProduct = Instantiate(material.finalProduct, spawnPoint);
    }

    private void Update()
    {
        // Cooldown timer de la fresadora
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        // Si existe un producto final al comenzar un nuevo producto, se elimina
        if (finalProduct)
        {
            Destroy(finalProduct);
        }

        // Si no hay elementos en cola de producción, no se hace nada más
        if (productionQueue.Count == 0)
        {
            return;
        }

        // Si no se ha spawnado el material base, hazlo
        if (!isBaseMaterialSpawned)
        {
            SpawnBaseMaterial(productionQueue[0].material, station1SpawnPoint);
            isBaseMaterialSpawned = true;
        }

        // Incrementar el tiempo de producción
        productionTimer += Time.deltaTime;

        // Si el tiempo de producción es mayor al tiempo de manufactura, spawnea el producto final
        if (productionTimer > productionQueue[0].material.manufacturingTime)
        {
            CompleteProduction();
        }
    }

    private void CompleteProduction()
    {
        Destroy(baseMaterial);
        SpawnFinalProduct(productionQueue[0].material, station2SpawnPoint);
        RemoveFromQueue(productionQueue[0]);
        productionTimer = 0;
        isBaseMaterialSpawned = false;

        // Se reinicia el cooldown
        cooldownTimer = cooldownTime;
    }
}