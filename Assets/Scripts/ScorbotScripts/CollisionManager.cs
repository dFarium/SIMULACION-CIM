using UnityEngine;
using UnityEngine.Serialization;

namespace ScorbotScripts
{
    public class CollisionManager : MonoBehaviour
    {
        [Header("Colliders a ignorar")]
        [SerializeField] private MeshCollider[] meshColliders;
        [SerializeField] private Collider[] otherColliders;
        [Header("Capas de colision")]
        [SerializeField] private int collisionLayer;
        [SerializeField] private int defaultLayer;


        private void Start()
        {
            //Ignorar colisiones con piezas adyacentes
            MeshCollider modelMeshCollider = GetComponent<MeshCollider>();
            foreach (MeshCollider meshCollider in meshColliders)
            {
                Physics.IgnoreCollision(meshCollider, modelMeshCollider, true);
            }
            
            foreach (Collider collider in otherColliders)
            {
                Physics.IgnoreCollision(collider, modelMeshCollider, true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name + " esta chocando con " + other.name);
            gameObject.layer = collisionLayer;
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(gameObject.name + " dejo de chocar");
            gameObject.layer = defaultLayer;
        }
    }
}