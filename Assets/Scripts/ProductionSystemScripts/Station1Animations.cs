using System.Collections;
using System.Collections.Generic;
using ScorbotScripts;
using UnityEngine;

public class Station1Animations : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo animationState;
    private float normalizedTime;
    private PickUpObject pickUpObject;
    private bool flag = true;
    private List<string> animationStates = new List<string>();
    private int animationIndex = 0;

// Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pickUpObject = GetComponentInChildren<PickUpObject>();
        animationStates.Add("Idle");
        animationStates.Add("SlideAruco");
        animationStates.Add("SlideAruco");
        animationStates.Add("LeaveAruco");
        animator.Play(animationStates[0]);
    }

    //Update is called once per frame
    void Update()
    {
        animationState = animator.GetCurrentAnimatorStateInfo(0);
        normalizedTime = animationState.normalizedTime;
        
        
        if(animationState.IsName("LeaveAruco") && !pickUpObject._isObjectPicked)
        {
            pickUpObject.PickUpToggle();
        }
        
    }

    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
    }
}