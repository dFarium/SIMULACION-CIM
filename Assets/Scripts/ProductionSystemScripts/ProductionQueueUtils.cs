using System.Collections.Generic;

public static class ProductionQueueUtils
{
    // Ordena la cola de producción por prioridad, de mayor a menor
    public static List<ProductionQueueItem> SortByPriority(this List<ProductionQueueItem> productionQueue)
    {
        productionQueue.Sort((a, b) => b.priority.CompareTo(a.priority));
        return productionQueue;
    }

    // Ordena la cola de producción por entrada, de menor a mayor
    public static List<ProductionQueueItem> SortByFifo(this List<ProductionQueueItem> productionQueue)
    {
        productionQueue.Sort((a, b) => a.queueNumber.CompareTo(b.queueNumber));
        return productionQueue;
    }

    // Ordena la cola de producción por entrada, de mayor a menor
    public static List<ProductionQueueItem> SortByLifo(this List<ProductionQueueItem> productionQueue)
    {
        productionQueue.Sort((a, b) => b.queueNumber.CompareTo(a.queueNumber));
        return productionQueue;
    }

    // Ordena la cola de producción por tiempo de manufactura, de menor a mayor
    public static List<ProductionQueueItem> SortByTime(this List<ProductionQueueItem> productionQueue)
    {
        productionQueue.Sort((a, b) => a.manufacturingTime.CompareTo(b.manufacturingTime));
        return productionQueue;
    }

    // Ordena la cola de producción por tiempo de manufactura, de mayor a menor
    public static List<ProductionQueueItem> SortByTimeInverted(this List<ProductionQueueItem> productionQueue)
    {
        productionQueue.Sort((a, b) => b.manufacturingTime.CompareTo(a.manufacturingTime));
        return productionQueue;
    }

    // Elimina el primer elemento de la cola de producción
    public static List<ProductionQueueItem> RemoveFirstFromQueue(this List<ProductionQueueItem> productionQueue)
    {
        if (productionQueue.Count > 0)
        {
            productionQueue.RemoveAt(0);
        }

        return productionQueue;
    }
    
    //Ordena la cola de producción según el tipo de ordenamiento seleccionado en el dropdown
    public static void SortQueueByDropdownSelection(this List<ProductionQueueItem> productionQueue, ProductionManager.SortingType sortingType)
    {
        switch (sortingType)
        {
            case ProductionManager.SortingType.Priority:
                productionQueue.SortByPriority();
                break;
            case ProductionManager.SortingType.Fifo:
                productionQueue.SortByFifo();
                break;
            case ProductionManager.SortingType.Lifo:
                productionQueue.SortByLifo();
                break;
            case ProductionManager.SortingType.LongestTime:
                productionQueue.SortByTime();
                break;
            case ProductionManager.SortingType.LeastTime:
                productionQueue.SortByTimeInverted();
                break;
            default:
                // Si se selecciona un tipo no reconocido, ordena por prioridad por defecto
                productionQueue.SortByPriority();
                break;
        }
    }
    
    // Devuelve el siguiente elemento en la cola de producción después del índice proporcionado, o null si dicho elemento no existe
    public static ProductionQueueItem GetItem(this List<ProductionQueueItem> productionQueue, int index)
    {
        if (index < productionQueue.Count)
        {
            return productionQueue[index];
        }

        return null;
    }

    
}