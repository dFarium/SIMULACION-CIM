using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Movimiento horizontal (WASD)
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Movimiento vertical (espacio y control)
        float verticalMovement = 0.0f;
        if (Input.GetKey(KeyCode.Space))
            verticalMovement = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            verticalMovement = -moveSpeed * Time.deltaTime;

        // Aplicar el movimiento
        Vector3 movement = transform.TransformDirection(new Vector3(horizontal, verticalMovement, vertical));
        transform.position += movement;

        // Rotación con el mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up, mouseX, Space.World);
    }
}