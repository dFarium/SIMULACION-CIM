using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletUtils : MonoBehaviour
{
    public delegate void PalletSpawnedAction(GameObject pallet);

    public static event PalletSpawnedAction OnPalletSpawned;


    private void SetPallet()
    {
        OnPalletSpawned?.Invoke(gameObject);
    }

    private void Start()
    {
        SetPallet();
    }
}