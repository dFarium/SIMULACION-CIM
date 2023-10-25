using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCameraBase> _virtualCameras;
    [SerializeField] private CinemachineVirtualCameraBase _defaultCamera;
    private CinemachineVirtualCameraBase _activeCamera;


    public void Start()
    {
        SwitchCamera(_defaultCamera);
    }

    public void SwitchCamera(CinemachineVirtualCameraBase camera)
    {
        foreach (CinemachineVirtualCameraBase virtualCameraBase in _virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        camera.gameObject.SetActive(true);
    }

    public void SwtichToDefaultCamera()
    {
        foreach (CinemachineVirtualCameraBase virtualCameraBase in _virtualCameras)
        {
            virtualCameraBase.gameObject.SetActive(false);
        }

        _defaultCamera.gameObject.SetActive(true);
    }
}