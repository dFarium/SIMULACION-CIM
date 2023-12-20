using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [Header("Station Cameras")]
    [SerializeField] private List<CinemachineVirtualCameraBase> station1Cameras = new List<CinemachineVirtualCameraBase>();
    [SerializeField] private List<CinemachineVirtualCameraBase> station2Cameras = new List<CinemachineVirtualCameraBase>();
    [SerializeField] private List<CinemachineVirtualCameraBase> station3Cameras = new List<CinemachineVirtualCameraBase>();
    [Header("Ring Buffer Cameras")]
    [SerializeField] private List<CinemachineVirtualCameraBase> station1RingBufferCameras = new List<CinemachineVirtualCameraBase>();
    [SerializeField] private List<CinemachineVirtualCameraBase> station2RingBufferCameras = new List<CinemachineVirtualCameraBase>();
    [SerializeField] private List<CinemachineVirtualCameraBase> station3RingBufferCameras = new List<CinemachineVirtualCameraBase>();
    [Header("Default Cameras")]
    [SerializeField] private CinemachineVirtualCameraBase sceneDefaultCamera;
    [SerializeField] private CinemachineVirtualCameraBase station1DefaultCamera;
    [SerializeField] private CinemachineVirtualCameraBase station2DefaultCamera;
    [SerializeField] private CinemachineVirtualCameraBase station3DefaultCamera;
    
    [Header("Production System Cameras")]   
    [SerializeField] private FloatingCamera _floatingCamera;
    [SerializeField] private List<CinemachineVirtualCameraBase> virtualCameras = new List<CinemachineVirtualCameraBase>();
    [SerializeField] private CinemachineVirtualCameraBase defaultCamera;
    public int currentStationIndex = 0;
    private int currentCameraIndexStation1 = 1;
    private int currentCameraIndexStation2 = 1;
    private int currentCameraIndexStation3 = 1;
    private CinemachineVirtualCameraBase _activeCamera;

    public void Start()
    {
        SwitchToSceneDefaultCamera();
    }
    
    public void SwitchToSceneDefaultCamera()
    {
        if(sceneDefaultCamera != null) SwitchToCamera(sceneDefaultCamera);
    }

    public void DisableAllCameras()
    {
        if(sceneDefaultCamera != null) sceneDefaultCamera.gameObject.SetActive(false);
        DisableCameras(station1Cameras);
        DisableCameras(station2Cameras);
        DisableCameras(station3Cameras);
    }
    public void DisableCameras(IEnumerable<CinemachineVirtualCameraBase> cameras)
    {
        foreach (var virtualCamera in cameras)
        {
            virtualCamera.gameObject.SetActive(false);
        }
    }

    public void SwitchToNextCameraStation1()
    {
        DisableAllCameras();
        station1RingBufferCameras[currentCameraIndexStation1].gameObject.SetActive(true);
        currentCameraIndexStation1 = (currentCameraIndexStation1 + 1) % 3;
    }
    
    public void SwitchToNextCameraStation2()
    {
        DisableAllCameras();
        station2RingBufferCameras[currentCameraIndexStation2].gameObject.SetActive(true);
        currentCameraIndexStation2 = (currentCameraIndexStation2 + 1) % 3;
    }
    
    public void SwitchToNextCameraStation3()
    {
        DisableAllCameras();
        station3RingBufferCameras[currentCameraIndexStation3].gameObject.SetActive(true);
        currentCameraIndexStation3 = (currentCameraIndexStation3 + 1) % 3;
    }

    public void SwitchToCamera(CinemachineVirtualCameraBase camera)
    {
        DisableAllCameras();
        camera.gameObject.SetActive(true);
    }
    
    public void SwitchToDefaultStationCameraFromIndex(int index)
    {
        switch (index)
        {
            case 0:
                DisableAllCameras();
                currentStationIndex = 0;
                station1DefaultCamera.gameObject.SetActive(true);
                break;
            case 1:
                DisableAllCameras();
                currentStationIndex = 1;
                station2DefaultCamera.gameObject.SetActive(true);

                break;
            case 2:
                DisableAllCameras();
                currentStationIndex = 2;
                station3DefaultCamera.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Opcion no valida");
                break;
        }
    }




    

    public void SwitchCameraDropdown(int cameraIndex)
    {
        Debug.Log(cameraIndex);
        foreach (CinemachineVirtualCameraBase virtualCameraBase in virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        virtualCameras[cameraIndex].gameObject.SetActive(true);

        if (cameraIndex == 5)
        {
            _floatingCamera.EnableCamera();
        }
    }
}