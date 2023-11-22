using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station2Animations : StationAnimationsBase
{
    [SerializeField] private Transform millBase;
    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
    }

    public void StopAnimation()
    {
        animator.SetBool("IDLING", true);
    }

    public void SetMaterialInMill()
    {
        LeaveMaterialInPosition(0);
        currentMaterial.transform.SetParent(millBase.transform);
    }
}