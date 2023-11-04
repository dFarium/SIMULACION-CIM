using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    [SerializeField] private MeshCollider[] meshColliders;


    private void Start()
    {
        //Ignorar colisiones con piezas adyacentes
        MeshCollider modelMeshCollider = GetComponent<MeshCollider>();
        foreach (MeshCollider meshCollider in meshColliders)
        {
            Physics.IgnoreCollision(meshCollider, modelMeshCollider, true);
        }
    }
}
