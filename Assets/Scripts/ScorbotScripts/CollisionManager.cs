using UnityEngine;
using UnityEngine.Serialization;

namespace ScorbotScripts
{
    public class CollisionManager : MonoBehaviour
    {
        [SerializeField] private MeshCollider[] meshColliders;
        private Material _highlightMaterial;
        private bool highlightCollision;
        private Material _baseMaterial;
        private MeshRenderer _meshRenderer;
        private CollisionBase _collisionBase;


        private void Start()
        {
            //Obtener material de la pieza
            _meshRenderer = GetComponent<MeshRenderer>();
            _baseMaterial = _meshRenderer.material;

            //Obtener material para destacar
            _collisionBase = GetComponentInParent<CollisionBase>();
            _highlightMaterial = _collisionBase.highlightMaterial;

            //Ignorar colisiones con piezas adyacentes
            MeshCollider modelMeshCollider = GetComponent<MeshCollider>();
            foreach (MeshCollider meshCollider in meshColliders)
            {
                Physics.IgnoreCollision(meshCollider, modelMeshCollider, true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name + " esta chocando con " + other.name);
            if (_collisionBase.highlightCollision) _meshRenderer.material = _highlightMaterial;
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(gameObject.name + " dejo de chocar");
            if (_collisionBase.highlightCollision) _meshRenderer.material = _baseMaterial;
        }
    }
}