using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Time = UnityEngine.Time;

public class ProductionManager : MonoBehaviour
{
    [Header("Station Animations")] [SerializeField]
    private Station1Animations station1;

    [SerializeField] private Station2Animations station2;
    [SerializeField] private Station3Animations station3;

    [FormerlySerializedAs("millAnimations")] [SerializeField]
    private MillAnimations mill;

    [Header("Station Lights")] [SerializeField]
    private List<GameObject> stationLights = new List<GameObject>();

    [Header("Pallet Related")] [SerializeField]
    private PalletUtils pallet;

    [SerializeField] private Transform baseMaterialSpawnPoint;
    [SerializeField] private Transform arucoSpawnPoint;
    [SerializeField] private GameObject aruco;
    private GameObject currentAruco;

    [Header("Production Settings & Status")] [SerializeField]
    private GameObject currentProduction;

    [SerializeField] private ProductionMaterial currentProductionMaterial;
    [SerializeField] private List<ProductionQueueItem> productionQueue = new List<ProductionQueueItem>();
    [FormerlySerializedAs("currentQueueItem")] public ProductionQueueItem currentProductionQueueItem;
    private SortingType sortingType = SortingType.Priority;
    private int queueCounter = 0;
    private GameObject currentFinalProduct;


    // Agrega un elemento a la cola de producción
    public void AddToQueue(ProductionMaterial productionMaterial, float priority, bool isBeingStored)
    {
        queueCounter++;
        var newItem = new ProductionQueueItem(productionMaterial, priority, isBeingStored, queueCounter);
        productionQueue.Add(newItem);
        productionQueue.SortQueueByDropdownSelection(sortingType);

        // If this was the first item added to the queue and the pallet has arrived, start an animation.
        if (productionQueue.Count >= 1 && pallet.stationIndex == 1 && pallet.hasArrived)
        {
            Debug.Log("pasa por aqui?");
            OnPalletArrived(pallet.stationIndex, pallet.hasArrived);
        }
    }


    // Spawnea el material base en la fresadora
    private void SpawnBaseMaterial(ProductionMaterial productionMaterial, Transform spawnPoint)
    {
        currentAruco = Instantiate(aruco, arucoSpawnPoint.position, arucoSpawnPoint.rotation);
        currentProduction = Instantiate(productionMaterial.baseMaterial, spawnPoint.position, spawnPoint.rotation);
    }

    public void ResetProductionQueue()
    {
        productionQueue.Clear();
        queueCounter = 0;
    }

    //Cuando llega pallet a estacion, comenzar animacion
    public void OnPalletArrived(int currentStation)
    {
        //Si la estación es la 1 y hay elementos en la cola de producción...
        if (currentStation == 0 && productionQueue.Count > 0)
        {
            //Si no se ha creado el material base aún y no hay ninguna producción en curso
            SetCurrentProduction();
        }

        // Si hay una producción en curso...
        if (currentProduction)
        {
            // Iniciamos la animación de producción
            StartStationAnimation(currentStation);
        }
    }
    
    //Para cuando no hay cola de producción antes de llegar a la estación 1 y se le agrega despues
    public void OnPalletArrived(int currentStation,bool hasArrived)
    {
        if (currentStation == 1 && productionQueue.Count > 0 && hasArrived)
        {
            //Si no se ha creado el material base aún y no hay ninguna producción en curso
            SetCurrentProduction();
        }

        // Si hay una producción en curso...
        if (currentProduction)
        {
            // Iniciamos la animación de producción
            StartStationAnimation(0);
        }
    }

    public void SetCurrentProduction()
    {
        if (!currentProduction)
        {
            //Obtener el primer elemento
            currentProductionQueueItem = productionQueue[0];
            currentProductionMaterial = currentProductionQueueItem.productionMaterial;

            //Crear material base en almacén de la estación 1
            SpawnBaseMaterial(currentProductionQueueItem.productionMaterial, baseMaterialSpawnPoint);
                
        }
    }

    public void StartStationAnimation(int currentStation)
    {
        switch (currentStation)
        {
            case 0:
                station1.StartAnimation();
                break;
            case 1:
                station2.StartAnimation();
                break;
            case 2:
                station3.StartAnimation();
                break;
        }
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

    public IEnumerator MaterialProductionConversion()
    {
        yield return new WaitForSeconds(currentProductionMaterial.manufacturingTime);
        mill.StopMillAnimation();
        MeshRenderer meshRenderer = currentProduction.GetComponent<MeshRenderer>();
        meshRenderer.material = currentProductionMaterial.finalProductMaterial;
    }

    public void EndCurrentProduction()
    {
        if (currentProduction)
        {
            Destroy(currentProduction);
            Destroy(currentAruco);
            currentProduction = null;
            productionQueue.RemoveFirstFromQueue();
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