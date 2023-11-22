using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station3Animations : StationAnimationsBase
{
    [SerializeField] private Transform storagePosition;
    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
    }

    public void StopAnimation()
    {
        animator.SetBool("IDLING", true);
    }
    
    public void SetMaterialInStorage(int storageIndex)
    {
        LeaveMaterialInPosition(storageIndex);
        currentMaterial.transform.SetParent(storagePosition);
    }
}
