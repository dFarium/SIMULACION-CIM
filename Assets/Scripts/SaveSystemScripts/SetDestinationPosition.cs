using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationPosition : MonoBehaviour
{
    [SerializeField] private int stationNumber, saveNumber;
    
    public void LoadAndSetPosition()
    {
        Vector3? newPosition = PositionManager.LoadPosition(stationNumber,saveNumber);
        if (newPosition == null) return;
        transform.position = (Vector3)newPosition;
    }

    public void SavePosition()
    {
        PositionManager.SavePosition(stationNumber,saveNumber,transform.position);
    }
}
