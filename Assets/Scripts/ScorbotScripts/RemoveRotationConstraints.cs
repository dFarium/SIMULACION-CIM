using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRotationConstraints : MonoBehaviour
{
    private Rigidbody[] _rigidBodies;
    public void Start()
    {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
    }

    public void RemoveConstraints()
    {
        foreach (Rigidbody rigidBody in _rigidBodies )
        {
            rigidBody.constraints = RigidbodyConstraints.None;
        }
    }
}
