using System;
using System.Collections;
using System.Collections.Generic;
using ScorbotScripts;
using UnityEngine;

public class Station1Animations : StationAnimationsBase
{
// Start is called before the first frame update
    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
        animator.SetBool("LEAVEPALLET", false);
    }

    public void StopAnimation()
    {
        animator.SetBool("IDLING", true);
    }

    public override void MovePalletToNextStation()
    {
        currentPallet.GetComponent<PalletUtils>().MoveToNextStation();
        animator.SetBool("LEAVEPALLET", true);
    }
}