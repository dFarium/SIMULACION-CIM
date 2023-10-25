using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreelookMovement : MonoBehaviour
{
    private void OnEnable()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    private void OnDisable()
    {
        CinemachineCore.GetInputAxis = UnityEngine.Input.GetAxis;
    }

    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            }
            else
            {
                return 0;
            }
        }

        return UnityEngine.Input.GetAxis(axisName);
    }
}