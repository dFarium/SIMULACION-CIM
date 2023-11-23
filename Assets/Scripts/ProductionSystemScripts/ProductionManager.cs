using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Time = UnityEngine.Time;

public class ProductionManager : MonoBehaviour
{
    //TODO REHACER GESTOR DE PRODUCCIÓN
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
    private int queueCounter = 0;
    private SortingType sortingType = SortingType.Priority;


    // Agrega un elemento a la cola de producción
    public void AddToQueue(ProductionMaterial productionMaterial, float priority, bool requiresManualReview,
        float manufacturingTime)
    {
        queueCounter++;
        ProductionQueueItem newItem =
            new ProductionQueueItem(productionMaterial, priority, requiresManualReview, queueCounter);
        productionQueue.Add(newItem);
        productionQueue.SortQueueByDropdownSelection(sortingType);
    }


    // Spawnea el material base en la fresadora
    private void SpawnBaseMaterial(ProductionMaterial productionMaterial, Transform spawnPoint)
    {
        currentProduction = Instantiate(productionMaterial.baseMaterial, spawnPoint);
    }

    //TODO REHACER GESTOR DE PRODUCCIÓN
    // private void Update()
    // {
    //     // Cooldown timer de la fresadora
    //     if (cooldownTimer > 0)
    //     {
    //         cooldownTimer -= Time.deltaTime;
    //         return;
    //     }
    //
    //     // Si existe un producto final al comenzar un nuevo producto, se elimina
    //     if (finalProduct)
    //     {
    //         Destroy(finalProduct);
    //     }
    //
    //     // Si no hay elementos en cola de producción, no se hace nada más
    //     if (productionQueue.Count == 0)
    //     {
    //         return;
    //     }
    //
    //     // Si no se ha spawnado el material base, hazlo
    //     if (!isBaseMaterialSpawned)
    //     {
    //         SpawnBaseMaterial(productionQueue[0].productionMaterial, station2SpawnPoint);
    //         isBaseMaterialSpawned = true;
    //     }
    //
    //     // Incrementar el tiempo de producción
    //     productionTimer += Time.deltaTime;
    //
    //     // Si el tiempo de producción es mayor al tiempo de manufactura, spawnea el producto final
    //     if (productionTimer > productionQueue[0].productionMaterial.manufacturingTime)
    //     {
    //         CompleteProduction();
    //     }
    // }

    // Lógica de spawneo del producto final
    private void CompleteProduction()
    {
        // Se coloca el color al producto final
        MeshRenderer meshRenderer = currentProduction.GetComponent<MeshRenderer>();
        meshRenderer.material = productionQueue[0].productionMaterial.finalProductMaterial;
        finalProduct = currentProduction;
        productionQueue.RemoveFirstFromQueue();
        productionTimer = 0;
        isBaseMaterialSpawned = false;

        // Se reinicia el cooldown
        cooldownTimer = cooldownTime;
    }

    public void ResetProductionQueue()
    {
        productionQueue.Clear();
        queueCounter = 0;
    }

    public void DropdownIndexChanged(int index)
    {
        // Asegurarse de que el índice esté dentro de los límites del enum SortingType
        if (index >= 0 && index < System.Enum.GetNames(typeof(SortingType)).Length)
        {
            sortingType = (SortingType)index;
            Debug.Log("SortingType changed to: " + sortingType);

            // Llamar al método SortQueue con el nuevo tipo de ordenamiento
            productionQueue.SortQueueByDropdownSelection(sortingType);
        }
        else
        {
            Debug.LogWarning("Index out of range for SortingType");
        }
    }

    public enum SortingType
    {
        Priority,
        Fifo,
        Lifo,
        LongestTime,
        LeastTime
    }
}