using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScorbotScripts
{
    public class CollisionManager : MonoBehaviour
    {
        [Header("Colliders a ignorar")] [SerializeField]
        private MeshCollider[] meshColliders;

        [SerializeField] private Collider[] otherColliders;

        [Header("Capas de colision")] [SerializeField]
        private int collisionLayer;

        [SerializeField] private int defaultLayer;
        private bool isCurrentlyColliding;
        private bool isShaderActive = true;

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

        private void Update()
        {
            //Si no esta chocando con nada, o si el shader esta desactivado, volver a la capa default
            if (isCurrentlyColliding && isShaderActive)
            {
                if (gameObject.layer != collisionLayer)
                {
                    gameObject.layer = collisionLayer;
                }
            }
            else
            {
                if (gameObject.layer != defaultLayer)
                {
                    gameObject.layer = defaultLayer;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name + " esta chocando con " + other.name);
            isCurrentlyColliding = true;
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(gameObject.name + " dejo de chocar");
            isCurrentlyColliding = false;
        }

        private void OnEnable()
        {
            CollisionBase.OnToggleCollisionShaderToggled += ToggleShader;
        }

        private void OnDisable()
        {
            CollisionBase.OnToggleCollisionShaderToggled -= ToggleShader;
        }

        //Metodo que se ejecuta cuando se recibe el evento de cambiar el shader
        private void ToggleShader()
        {
            Debug.Log("CAMBIANDO SHADER");
            isShaderActive = !isShaderActive;
        }
    }
}