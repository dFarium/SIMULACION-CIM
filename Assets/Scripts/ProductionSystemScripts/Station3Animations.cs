using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station3Animations : StationAnimationsBase
{
    [SerializeField] private Transform storagePosition;
    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
        animator.SetBool("LEAVEPALLET", false);
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
    
    public override void MovePalletToNextStation()
    {
        currentPallet.GetComponent<PalletUtils>().MoveToNextStation();
        animator.SetBool("LEAVEPALLET", true);
        productionManager.EndCurrentProduction();
    }

    public void SetStorage()
    {
        animator.SetBool("IsBeingStored", productionManager.currentProductionQueueItem.isBeingStored);
    }
}
