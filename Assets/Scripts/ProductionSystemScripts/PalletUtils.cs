using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PalletUtils : MonoBehaviour
{
    public delegate void PalletSpawnedAction(GameObject pallet);

    public static event PalletSpawnedAction OnPalletSpawned;

    [SerializeField] private Transform[] stationsWaypoints;
    [SerializeField] private float targetDistance = 0.1f;
    [SerializeField] private int stationIndex = 0;
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
            tweenPath.DOPause();
            gameObject.transform.position = stationsWaypoints[stationIndex].position;
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
        tweenPath.DOPlay();
    }
}