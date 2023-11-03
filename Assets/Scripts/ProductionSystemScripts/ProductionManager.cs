using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProductionManager : MonoBehaviour
{
    [Header("Production Status")] [SerializeField]
    private float productionTimer;

    [SerializeField] private GameObject currentProduction;
    [SerializeField] private GameObject finalProduct;
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private float cooldownTimer = 0;
    [SerializeField] private Transform station1SpawnPoint, station2SpawnPoint;
    [SerializeField] private List<ProductionQueueItem> productionQueue = new List<ProductionQueueItem>();
    private GameObject currentFinalProduct; // Variable para almacenar el producto final actual
    private bool isBaseMaterialSpawned;

    // Clase para almacenar los elementos de la cola de producción
    [System.Serializable]
    public class ProductionQueueItem
    {
        [FormerlySerializedAs("material")] public ProductionMaterial productionMaterial;
        public float priority;
        public bool requiresManualReview;
        
        public ProductionQueueItem(ProductionMaterial productionMaterial, float priority, bool requiresManualReview)
        {
            this.productionMaterial = productionMaterial;
            this.priority = priority;
            this.requiresManualReview = requiresManualReview;
        }
    }

    // Agrega un elemento a la cola de producción
    public void AddToQueue(ProductionMaterial productionMaterial, float priority, bool requiresManualReview)
    {
        ProductionQueueItem newItem = new ProductionQueueItem(productionMaterial, priority, requiresManualReview);
        productionQueue.Add(newItem);
        SortQueueByPriority(); // Ordena la cola después de agregar un elemento.
    }

    // Elimina un elemento de la cola de producción
    public void RemoveFromQueue(ProductionQueueItem item)
    {
        productionQueue.Remove(item);
    }

    //Ordena la cola de producción por prioridad, de mayor a menor
    public void SortQueueByPriority()
    {
        productionQueue.Sort((a, b) => b.priority.CompareTo(a.priority));
    }
    
    // Spawnea el material base en la fresadora
    public void SpawnBaseMaterial(ProductionMaterial productionMaterial, Transform spawnPoint)
    {
        currentProduction = Instantiate(productionMaterial.baseMaterial, spawnPoint);
    }
    
    //Lógica de producción
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
            SpawnBaseMaterial(productionQueue[0].productionMaterial, station2SpawnPoint);
            isBaseMaterialSpawned = true;
        }

        // Incrementar el tiempo de producción
        productionTimer += Time.deltaTime;

        // Si el tiempo de producción es mayor al tiempo de manufactura, spawnea el producto final
        if (productionTimer > productionQueue[0].productionMaterial.manufacturingTime)
        {
            CompleteProduction();
        }
    }

    // Lógica de spawneo del producto final
    private void CompleteProduction()
    {
        // Se coloca el color al producto final
        MeshRenderer meshRenderer = currentProduction.GetComponent<MeshRenderer>();
        meshRenderer.material = productionQueue[0].productionMaterial.finalProductMaterial;
        finalProduct = currentProduction;
        RemoveFromQueue(productionQueue[0]);
        productionTimer = 0;
        isBaseMaterialSpawned = false;

        // Se reinicia el cooldown
        cooldownTimer = cooldownTime;
    }
}