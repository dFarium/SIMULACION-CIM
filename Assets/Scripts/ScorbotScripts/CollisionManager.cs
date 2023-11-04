using UnityEngine;
using UnityEngine.Serialization;

namespace ScorbotScripts
{
    public class CollisionManager : MonoBehaviour
    {
        [SerializeField] private MeshCollider[] meshColliders;
        [SerializeField] private int collisionLayer,defaultLayer;


        private void Start()
        {
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
            gameObject.layer = collisionLayer;
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(gameObject.name + " dejo de chocar");
            gameObject.layer = defaultLayer;
        }
    }
}