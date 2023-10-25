using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FloatingCamera : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private Transform startPosition;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float defaultHorizontalValue, defaultVerticalValue;
    private Camera camera1;


    private void Start()
    {
        camera1 = Camera.main;
    }

    private void Update()
    {
        // Desbloquea cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        HorizontalMovement();
        VerticalMovement();
    }

    private void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0 && verticalInput == 0) return;

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Obtén la rotación actual de la cámara.
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // Calcula la dirección de movimiento en función de la rotación de la cámara.
        Vector3 move = direction.x * camera1.transform.right + direction.z * cameraForward;

        // Aplica el movimiento.
        transform.Translate(move * (moveSpeed * Time.deltaTime));
    }

    private void VerticalMovement()
    {
        //Elevación de la camara
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraManager.SwtichToDefaultCamera();
    }

    public void EnableCamera()
    {
        CinemachinePOV pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.Value = defaultHorizontalValue;
        pov.m_VerticalAxis.Value = defaultVerticalValue;
        transform.position = startPosition.position;
        LockCursor();
    }
}