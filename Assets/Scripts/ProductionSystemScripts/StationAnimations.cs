using System.Collections;
using System.Collections.Generic;
using ScorbotScripts;
using UnityEngine;

public class StationAnimations : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo animationState;
    private float normalizedTime;
    private PickUpObject pickUpObject;
    private List<string> animationStates = new List<string>();
    private int animationIndex = 0;
    private GameObject currentAruco,currentMaterial;
    public GameObject currentPallet;
    
    [SerializeField]private List<Transform> arucoTargetTransforms = new List<Transform>();

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
    }

    public void StartAnimation()
    {
        animator.SetBool("IDLING", false);
    }

    public void StopAnimation()
    {
        animator.SetBool("IDLING", true);
    }

    public void PickObject()
    {
        pickUpObject.PickUpToggle();
        if (pickUpObject._pickedObject != null && pickUpObject._pickedObject != currentAruco && pickUpObject._pickedObject.CompareTag("Aruco"))
        {
            currentAruco = pickUpObject._pickedObject;
        }
        else if (pickUpObject._pickedObject != null && pickUpObject._pickedObject != currentMaterial && pickUpObject._pickedObject.CompareTag("Material"))
        {
            currentMaterial = pickUpObject._pickedObject;
        }
    }

    public void LeaveArucoInPosition(int listIndex)
    {
        currentAruco.transform.position = arucoTargetTransforms[listIndex].position;
        currentAruco.transform.rotation = arucoTargetTransforms[listIndex].rotation;
    }
    
    public void LeaveMaterialInPosition(int listIndex)
    {
        currentMaterial.transform.position = arucoTargetTransforms[listIndex].position;
        currentMaterial.transform.rotation = arucoTargetTransforms[listIndex].rotation;
    }

    public void SetParentToMaterial()
    {
        currentMaterial.transform.parent = currentAruco.transform;
    }
    
    public void SetParentToAruco()
    {
        currentAruco.transform.parent = currentPallet.transform;
    }
}