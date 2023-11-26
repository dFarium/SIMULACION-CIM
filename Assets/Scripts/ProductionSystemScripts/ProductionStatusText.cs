using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ProductionManager;

public class ProductionStatusText : MonoBehaviour
{
    [SerializeField] private ProductionManager productionManager;

    private TMPro.TextMeshProUGUI statusText;

    // Start is called before the first frame update
    private void Start()
    {
        statusText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateText(ProductionManager.ProductionStatus status)
    {
        Debug.Log("Updating text");
        statusText.text = GetStatusString(status);
    }

    public string GetStatusString(ProductionStatus status)
    {
        switch (status)
        {
            case ProductionStatus.Idle:
                return "Inactivo";
            case ProductionStatus.ToStation1:
                return "A la estación 1";
            case ProductionStatus.GettingMaterial:
                return "Obteniendo Material";
            case ProductionStatus.ToStation2:
                return "A la estación 2";
            case ProductionStatus.Producing:
                return "Produciendo";
            case ProductionStatus.ToStation3:
                return "A la estación 3";
            case ProductionStatus.Storing:
                return "Almacenando";
            case ProductionStatus.Disposing:
                return "Desechando";
            case ProductionStatus.Finished:
                return "Terminado";
            default:
                return "Estado desconocido";
        }
    }
}