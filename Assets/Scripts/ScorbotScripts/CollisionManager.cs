using UnityEngine;

namespace ScorbotScripts
{
    public class CollisionManager : MonoBehaviour
    {
        [SerializeField] private MeshCollider[] _meshColliders;

    
        private void Start()
        {
            MeshCollider modelMeshCollider = GetComponent<MeshCollider>();
            foreach (MeshCollider meshCollider in _meshColliders)
            {
                Physics.IgnoreCollision(meshCollider,modelMeshCollider,true);
            }
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name + " esta chocando con " + other.name);
        }

    
        private void OnTriggerExit(Collider other)
        {
            Debug.Log(gameObject.name + " dejo de chocar");
        }
    
    }
}