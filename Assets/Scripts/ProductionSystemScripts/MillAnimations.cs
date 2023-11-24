using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillAnimations : MonoBehaviour
{
    [SerializeField] private Station2Animations station2Animations;
    [SerializeField] private ProductionManager productionManager;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PickUpFinalMaterial()
    {
        station2Animations.animator.SetBool("IsMaterialReady", true);
    }
    
    public void StartMillAnimation()
    {
        animator.SetBool("IDLING", false);
        animator.SetBool("HasFinished", false);
    }

    public void StartMillingCoroutine()
    {
        StartCoroutine(productionManager.MaterialProductionConversion());
    }
    
    public void StopMillAnimation()
    {
        animator.SetBool("HasFinished", true);
    }
}
