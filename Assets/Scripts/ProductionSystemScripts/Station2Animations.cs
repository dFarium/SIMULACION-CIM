using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Station2Animations : StationAnimationsBase
{
    [SerializeField] private Transform millBase;
    [SerializeField] private MillAnimations millAnimator;

    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
        animator.SetBool("LEAVEPALLET", false);
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
    
    public void StartMillAnimation()
    {
        millAnimator.StartMillAnimation();
    }
    
    public void StopMillAnimation()
    {
        millAnimator.StopMillAnimation();
    }
    
    public override void MovePalletToNextStation()
    {
        currentPallet.GetComponent<PalletUtils>().MoveToNextStation();
        animator.SetBool("LEAVEPALLET", true);
    }
}