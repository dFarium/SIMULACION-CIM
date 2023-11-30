using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCameraBase> virtualCameras;
    [SerializeField] private CinemachineVirtualCameraBase defaultCamera;

    [SerializeField]
    private List<CinemachineVirtualCameraBase> ringBufferCameras = new List<CinemachineVirtualCameraBase>();

    [SerializeField] private FloatingCamera _floatingCamera;
    private int currentCameraIndex = 1;
    private CinemachineVirtualCameraBase _activeCamera;


    public void OnEnable()
    {
        SwitchCamera(defaultCamera);
    }

    public void SwitchCamera(CinemachineVirtualCameraBase camera)
    {
        foreach (CinemachineVirtualCameraBase virtualCameraBase in virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        camera.gameObject.SetActive(true);
    }

    public void SwitchToNextCamera()
    {
        foreach (CinemachineVirtualCameraBase virtualCameraBase in virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        // Asume que currentCameraIndex es 0, 1 o 2.
        ringBufferCameras[currentCameraIndex].gameObject.SetActive(true);
        currentCameraIndex = (currentCameraIndex + 1) % 3;
    }

    public void SwtichToDefaultCamera()
    {
        foreach (CinemachineVirtualCameraBase virtualCameraBase in virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        defaultCamera.gameObject.SetActive(true);
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