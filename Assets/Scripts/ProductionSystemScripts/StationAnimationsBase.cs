using System.Collections;
using System.Collections.Generic;
using ScorbotScripts;
using UnityEngine;

public abstract class StationAnimationsBase : MonoBehaviour
{
    [SerializeField] protected ProductionManager productionManager;
    public Animator animator;
    protected GameObject currentAruco;
    protected GameObject currentMaterial;
    protected GameObject currentPallet;
    protected PickUpObject pickUpObject;
    public List<Transform> arucoTargetTransforms = new List<Transform>();
    public List<Transform> materialTargetTransforms = new List<Transform>();

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        pickUpObject = GetComponentInChildren<PickUpObject>();
        PalletUtils.OnPalletSpawned += SetCurrentPallet;
    }

    private void OnDestroy()
    {
        PalletUtils.OnPalletSpawned -= SetCurrentPallet;
    }

    private void Awake()
    {
        PalletUtils.OnPalletSpawned += SetCurrentPallet;
    }

    private void SetCurrentPallet(GameObject pallet)
    {
        currentPallet = pallet;
    }

    public void LeaveArucoInPosition(int listIndex)
    {
        currentAruco.transform.position = arucoTargetTransforms[listIndex].position;
        currentAruco.transform.rotation = arucoTargetTransforms[listIndex].rotation;
    }

    public void LeaveMaterialInPosition(int listIndex)
    {
        currentMaterial.transform.position = materialTargetTransforms[listIndex].position;
        currentMaterial.transform.rotation = materialTargetTransforms[listIndex].rotation;
    }

    public void PickObject()
    {
        pickUpObject.PickUpToggle();
        //Se asigna el objeto tomado a la variable correspondiente
        if (pickUpObject._pickedObject != null && pickUpObject._pickedObject != currentAruco &&
            pickUpObject._pickedObject.CompareTag("Aruco"))
        {
            currentAruco = pickUpObject._pickedObject;
        }
        else if (pickUpObject._pickedObject != null && pickUpObject._pickedObject != currentMaterial &&
                 pickUpObject._pickedObject.CompareTag("Material"))
        {
            currentMaterial = pickUpObject._pickedObject;
        }
    }


    public void SetParentToMaterial()
    {
        currentMaterial.transform.parent = currentAruco.transform;
    }

    public void SetParentToAruco()
    {
        currentAruco.transform.parent = currentPallet.transform;
    }
    
    public abstract void MovePalletToNextStation();
}