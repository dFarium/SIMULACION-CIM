using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletUtils : MonoBehaviour
{
    [SerializeField] StationAnimations station1, station2, station3;

    private void Start()
    {
        station1.currentPallet = gameObject;
    }
}