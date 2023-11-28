using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PalletUtils : MonoBehaviour
{
    public delegate void PalletSpawnedAction(GameObject pallet);

    public static event PalletSpawnedAction OnPalletSpawned;
    [SerializeField] private ProductionManager productionManager;
    public bool hasArrived = false;
    [SerializeField] private Transform[] stationsWaypoints;
    [SerializeField] private float targetDistance = 0.1f;
    public int stationIndex = 0;
    private DOTweenPath tweenPath;


    private void SetPallet()
    {
        OnPalletSpawned?.Invoke(gameObject);
    }

    private void Start()
    {
        tweenPath = GetComponent<DOTweenPath>();
        SetPallet();
    }
    
    private void FixedUpdate()
    {
        if (Vector3.Distance(gameObject.transform.position, stationsWaypoints[stationIndex].position) <= targetDistance)
        {
            //El pallet llega a la estación
            productionManager.CurrentProductionStatus = ProductionManager.ProductionStatus.Idle;
            tweenPath.DOPause();
            gameObject.transform.position = stationsWaypoints[stationIndex].position;
            productionManager.OnPalletArrived(stationIndex);
            hasArrived = true;
            UpdateIndex();
            
        }
    }

    //Dibuja una esfera en cada waypoint
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        foreach (Transform waypoint in stationsWaypoints)
        {
            Gizmos.DrawWireSphere(waypoint.position, targetDistance);
        }
    }

    //Actualiza el índice de la estación
    private void UpdateIndex()
    {
        Debug.Log(stationIndex);
        stationIndex++;
        if (stationIndex >= stationsWaypoints.Length)
        {
            stationIndex = 0;
        }
    }
    
    public void MoveToNextStation()
    {
        //Mantiene el valor entre 0 a 2
        int previousStationIndex = (stationIndex + 2) % 3;
        productionManager.OnPalletLeave(previousStationIndex);
        tweenPath.DOPlay();
        hasArrived = false;
    }
}